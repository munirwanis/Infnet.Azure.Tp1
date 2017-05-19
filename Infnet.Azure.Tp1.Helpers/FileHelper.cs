using Infnet.Azure.Tp1.Data;
using System;

namespace Infnet.Azure.Tp1.Helpers
{
    public class FileHelper
    {
        public static string[] Open(out string path)
        {
            string[] csv;
            do
            {
                Console.Write("Waiting for path from csv: ");
                path = Console.ReadLine();

                var reader = new CSVReader();

                csv = reader.ReadFromFile(path);

            } while (csv == null);
            return csv;
        }
    }
}
