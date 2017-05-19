using System;
using System.IO;

namespace Infnet.Azure.Tp1.Data
{
    public class CSVReader
    {
        public string[] ReadFromFile(string path)
        {
            if (File.Exists(path)) { return File.ReadAllLines(path); }
            else
            {
                Console.WriteLine("File not found.");
                Console.WriteLine("Press ENTER to try again or 0 to exit:");
                var s = Console.ReadKey();
                if (s.Key == ConsoleKey.D0)
                {
                    Environment.Exit(00);
                }
                return null;
            }
        }
    }
}
