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

        public static List<GameResult> ReadSoccerResults(string fileName)
        {
            List<GameResult> soccerResults = new List<GameResult>();
            string line = "";
            
            using(var reader = new StreamReader(fileName))
            {
                reader.ReadLine();               
                while((line = reader.ReadLine()) != null)
                {
                    var gameResult = new GameResult();
                    string[] values = line.Split(',');

                    //prase game date, team name,HomeOrAway, Goals, GoalAttempts, ShotsOnGoal, ShotsOffGoal, PosessionPercent
                    DateTime gameDate;
                    if(DateTime.TryParse(values[0], out gameDate))
                    {
                        gameResult.GameDate = gameDate;
                    }

                    gameResult.TeamName = values[1];

                    HomeOrAway homeOrAway;
                    if(Enum.TryParse(values[2], out homeOrAway))
                    {
                        gameResult.HomeOrAway = homeOrAway;
                    }

                    int parseInt;
                    if(int.TryParse(values[3], out parseInt))
                    {
                        gameResult.Goals = parseInt;
                    }

                    if (int.TryParse(values[4], out parseInt))
                    {
                        gameResult.GoalAttempts = parseInt;
                    }

                    if (int.TryParse(values[5], out parseInt))
                    {
                        gameResult.ShotOnGoal = parseInt;
                    }

                    if (int.TryParse(values[6], out parseInt))
                    {
                        gameResult.ShotOffGoal = parseInt;
                    }

                    double possessionPercent;
                    if(double.TryParse(values[7], out possessionPercent))
                    {
                        gameResult.PosessionPercent = possessionPercent;
                    }



                    soccerResults.Add(gameResult);
                }
            }
            return soccerResults;
        }
    }
}
