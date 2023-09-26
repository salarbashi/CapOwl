using Agent.Database;
using Agent.DataProviders.Models;
using Agent.DataProviders.YahooFinance;
using Microsoft.EntityFrameworkCore;

namespace Agent.Helpers
{
    public class Processor : IDisposable
    {
        public async Task ProcessSymbolsFromFile(string csvFileAddress, int batchSize, 
            YahooProvider yfinance, bool updateAllSymbols)
        {
            using (var reader = new StreamReader(csvFileAddress))
            {
                var rowCount = CSVReader.CountRowsInCSV(reader);
                int numberofBatches = (int)Math.Ceiling((decimal)rowCount / batchSize);
                int lastReadRowIndexTSX = 0;

                //Process batches
                for (int i = 0; i < numberofBatches; i++)
                {

                    List<CSVData> csvData = CSVReader.ReadNextBatchFromCSV(reader, batchSize, 
                        ref lastReadRowIndexTSX);

                    await ParallelSymbolProcess(yfinance, csvData, updateAllSymbols);
                }

            }
        }

        public async Task ParallelSymbolProcess(YahooProvider yfinance, List<CSVData> csvData,
            bool updateAllSymbols)
        {
            var tasks = csvData.Select(item => SymbolProcess(item, yfinance, updateAllSymbols)).ToList();
            await Task.WhenAll(tasks);
        }

        public async Task SymbolProcess(CSVData item, YahooProvider yfinance, bool updateAllSymbols)
        {
            using (var dbContext = new DatabaseContext())
            {
                var ticker = item.Ticker;
                try
                {
                    //check if it is already in symbol table
                    var dbSymbolExists = await dbContext.Symbols.AnyAsync(m => m.Ticker == ticker);

                    if (updateAllSymbols || !dbSymbolExists)
                    {
                        var summary = await yfinance.GetSymbolSummaryAsync(ticker);

                        var symbol = new Symbol
                        {
                            Ticker = ticker,
                            Name = summary.Name,
                            Sector = item.Sector,
                            SubSector = item.SubSector,
                            Type = summary.Type,
                            Country = summary.Country,
                            Exchange = summary.Exchange,
                        };

                        //Add or update
                        if (!dbSymbolExists)
                        {
                            //Add

                            await dbContext.Symbols.AddAsync(symbol);
                        }
                        else
                        {
                            //Update

                            var existingDbSymbol  = await dbContext.Symbols.
                                Where(m => m.Ticker == ticker).FirstAsync();
                            
                            //set new symbol id
                            symbol.Id = existingDbSymbol.Id;

                            //update existing dbsymbol
                            dbContext.Entry(existingDbSymbol).State = EntityState.Detached;
                            existingDbSymbol = symbol;
                            dbContext.Entry(existingDbSymbol).State = EntityState.Modified;
                        }
                        
                        await dbContext.SaveChangesAsync();
                        Console.WriteLine($"{ticker} symbol processed successfully!");
                    }
                    else
                    {
                        Console.WriteLine($"{ticker} already exists in symbol table!");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in symbol processing {ticker}. Exception:{ex.Message}");
                }
            }
        }

        public async Task ProcessSymbolsData(YahooProvider yfinance, int batchSize)
        {
            using (var dbContext = new DatabaseContext())
            {
                var numberOfSymbols = await dbContext.Symbols.CountAsync();
                int numberofBatches = (int)Math.Ceiling((decimal)numberOfSymbols / batchSize);

                for (int i = 0; i < numberofBatches; i++)
                {
                    var symbolsBatch = dbContext.Symbols.OrderBy(e => e.Id).Skip(i * batchSize).
                        Take(batchSize).ToList();

                    await ParallelSymbolsDataProcess(symbolsBatch, yfinance);
                }
            }
        }

        public async Task ParallelSymbolsDataProcess(List<Symbol> symbolsBatch, YahooProvider yfinance)
        {
            var tasks = symbolsBatch.Select(item => SymbolsDataProcess(item, yfinance)).ToList();
            await Task.WhenAll(tasks);
        }

        public async Task SymbolsDataProcess(Symbol symbol, YahooProvider yfinance)
        {
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    var fundamental = await yfinance.GetSymbolFullAsync(symbol.Ticker);

                    Fundamental newDbFundamental = new Fundamental
                    {
                        Symbol = await dbContext.Symbols.Where(e => e.Ticker == symbol.Ticker).SingleAsync(),
                        Beta = fundamental.Beta,
                        DebtToEquity = fundamental.DebtToEquity,
                        DividendYield = fundamental.DividendYield,
                        MarketCap = fundamental.MarketCap,
                        PayoutRatio = fundamental.PayoutRatio,
                        PeForward = fundamental.PeForward,
                        PriceToBook = fundamental.PriceToBook,
                        PriceToSales = fundamental.PriceToSales,
                        ProfitMargin = fundamental.ProfitMargin,
                        ReturnOnEquity = fundamental.ReturnOnEquity
                    };

                    MarketData newDbMarketData = new MarketData {
                    Symbol = await dbContext.Symbols.Where(e => e.Ticker == symbol.Ticker).SingleAsync(),
                    Close = fundamental.Close,
                    High = fundamental.High,
                    Low = fundamental.Low,
                    Open = fundamental.Open,
                    Volume = fundamental.Volume
                    };


                    #region update or insert fundamental

                    var oldDbFundamental = dbContext.Fundamentals.Include(e => e.Symbol).
                        Where(e => e.Symbol.Ticker == symbol.Ticker).SingleOrDefault();

                    if (oldDbFundamental != null)
                    {
                        //Update

                        //set new symbol id
                        newDbFundamental.Id = oldDbFundamental.Id;

                        //update existing dbsymbol
                        dbContext.Entry(oldDbFundamental).State = EntityState.Detached;
                        oldDbFundamental = newDbFundamental;
                        dbContext.Entry(oldDbFundamental).State = EntityState.Modified;
                    }
                    else
                    {
                        //Add

                        await dbContext.Fundamentals.AddAsync(newDbFundamental);
                    }
                    #endregion

                    #region update or insert market data

                    var oldDbMarketData = dbContext.MarketDatas.Include(e => e.Symbol).
                        Where(e => e.Symbol.Ticker == symbol.Ticker).SingleOrDefault();

                    if (oldDbMarketData != null)
                    {
                        //Update

                        //set new symbol id
                        newDbMarketData.Id = oldDbMarketData.Id;

                        //update existing dbsymbol
                        dbContext.Entry(oldDbMarketData).State = EntityState.Detached;
                        oldDbMarketData = newDbMarketData;
                        dbContext.Entry(oldDbMarketData).State = EntityState.Modified;
                    }
                    else
                    {
                        //Add

                        await dbContext.MarketDatas.AddAsync(newDbMarketData);
                    }

                    #endregion

                    //save DB changes
                    await dbContext.SaveChangesAsync();

                    Console.WriteLine($"{symbol.Ticker} symbol data processed successfully!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in symbol data processing {symbol.Ticker}. Exception:{ex.Message}");
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
