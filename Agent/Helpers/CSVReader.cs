using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.Helpers
{
    internal class CSVReader
    {
        internal static List<CSVData> ReadNextBatchFromCSV(StreamReader reader, int batchNumber, ref int lastReadRowIndex)
        {
            List<CSVData> dataList = new List<CSVData>();

            string? line;
            int rowCount = 0;

            while ((line = reader.ReadLine()) != null)
            {
                //rowCount++;

                //if (rowCount < lastReadRowIndex)
                //    continue; // Skip rows already read

                var fields = line.Split(',');

                if (fields.Length >= 2) // Assuming there are at least three fields in each row
                {
                    var ticker = fields[0].Trim();
                    var sector = fields[1].Trim();
                    //third field is not always available
                    var subSector = fields.Length >= 3 ? fields[2].Trim() : "";

                    CSVData excelRow = new CSVData
                    {
                        Ticker = ticker,
                        Sector = sector,
                        SubSector = subSector
                    };

                    dataList.Add(excelRow);
                }

                if (dataList.Count >= batchNumber)
                    break;
            }

            lastReadRowIndex += dataList.Count; // Update the last read index

            return dataList;
        }

        internal static int CountRowsInCSV(StreamReader reader)
        {
            int rowCount = 0;

            while (reader.ReadLine() != null)
            {
                rowCount++;
            }

            // Reset the reader's position to the beginning of the file
            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            reader.DiscardBufferedData();

            return rowCount;
        }
    }
}
