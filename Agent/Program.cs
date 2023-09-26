using Agent.DataProviders.YahooFinance;
using Agent.Database;
using Agent.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace Agent
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //initial variables
            string csvFileAddress = "";
            bool updateSymbolsData = false;
            bool updateAllSymbols = false;
            var yfinance = new YahooProvider();

            //**validation**
            if (args.Length < 1 || args.Length > 4)
            {
                Console.WriteLine("Usage: FinancialManagerAgent.exe <batchSize> [csvFileAddress] [updateAllSymbols] [updateSymbolsData]");
                Console.ReadLine();
                return;
            }

            //required parameters
            if (!int.TryParse(args[0], out int batchSize))
            {
                Console.WriteLine("Batch Size must be a valid integer.");
                return;
            }

            //***************

            //**initialization**

            //optional parameters
            if (args.Length > 1 && args[1] != "")
            {
                csvFileAddress = args[1];
            }

            if (args.Length > 2 && args[2] != "")
            {
                bool.TryParse(args[2], out updateAllSymbols);
            }

            if (args.Length > 3 && args[3] != "")
            {
                bool.TryParse(args[3], out updateSymbolsData);
            }

            Console.WriteLine("Batch Size: " + batchSize);
            Console.WriteLine("CSV File Address: " + csvFileAddress);
            //******************

            //process symbols
            try
            {
                if (!string.IsNullOrEmpty(csvFileAddress))
                {
                    using Processor processor = new();
                    await processor.ProcessSymbolsFromFile(csvFileAddress, batchSize, yfinance, updateAllSymbols);
                }
                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred in symbol process: " + ex.Message);
            }

            //process symbols data
            try
            {
                if(updateSymbolsData)
                {
                    using Processor processor = new();
                    await processor.ProcessSymbolsData(yfinance, batchSize);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred in fundamental process: " + ex.Message);
            }

            Console.WriteLine("Agent process finished successfully!");
            Console.ReadLine();
        }


    }


}


