using System;
using System.IO;
using System.Collections.Generic;

namespace SoccerStats
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "SoccerGameResults.csv");
            var file = new FileInfo(fileName);
            if (file.Exists)
            {
                var fileContents = ReadSoccerResults(fileName);

            }
            else
            {
                Console.WriteLine("No file exists");
            }

        }

        public static string ReadFile(string fileName)
        {
            using(var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        public static List<string[]> ReadSoccerResults(string fileName)
        {
            List<string[]> soccerResults = new List<string[]>();
            string line = "";
            
            using(var reader = new StreamReader(fileName))
            {
                reader.ReadLine();               
                while((line = reader.ReadLine()) != null)
                {
                    var gameResult = new GameResult();
                    string[] values = line.Split(',');
                    DateTime gameDate;
                    if(DateTime.TryParse(values[0], out gameDate))
                    {
                        gameResult.GameDate = gameDate;
                    }
                    soccerResults.Add(values);
                }
            }
            return soccerResults;
        }
    }
}
