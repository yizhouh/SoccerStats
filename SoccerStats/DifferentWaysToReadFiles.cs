using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SoccerStats
{
    public class DifferentWaysToReadFiles
    {
        public DifferentWaysToReadFiles()
        {
        }

        //read local file, like text, csv......
        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        //read csv files
        //split lines with ','  , put attributes in array
        public static List<GameResult> ReadSoccerResults(string fileName)
        {
            List<GameResult> soccerResults = new List<GameResult>();
            string line = "";

            using (var reader = new StreamReader(fileName))
            {
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    var gameResult = new GameResult();
                    string[] values = line.Split(',');

                    //parse game date, team name,HomeOrAway, Goals, GoalAttempts, ShotsOnGoal, ShotsOffGoal, PosessionPercent
                    DateTime gameDate;
                    if (DateTime.TryParse(values[0], out gameDate))
                    {
                        gameResult.GameDate = gameDate;
                    }

                    gameResult.TeamName = values[1];

                    HomeOrAway homeOrAway;
                    if (Enum.TryParse(values[2], out homeOrAway))
                    {
                        gameResult.HomeOrAway = homeOrAway;
                    }

                    int parseInt;
                    if (int.TryParse(values[3], out parseInt))
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
                    if (double.TryParse(values[7], out possessionPercent))
                    {
                        gameResult.PosessionPercent = possessionPercent;
                    }



                    soccerResults.Add(gameResult);
                }
            }
            return soccerResults;
        }


        //newtonsoft json serializer to serialize and deserialize files
        public static List<Player> DeserializePlayers(string fileName)
        {
            var players = new List<Player>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                players = serializer.Deserialize<List<Player>>(jsonReader);
            }
            return players;
        }

        public static List<Player> GetTopTenPlayers(List<Player> players)
        {
            var topTenPlayers = new List<Player>();
            players.Sort(new PlayerComparer());
            //or do comparer * -1 in PlayerComparer.cs
            players.Reverse();
            int count = 0;
            foreach (var player in players)
            {
                topTenPlayers.Add(player);
                count++;
                if (count == 10)
                {
                    break;
                }
            }
            return topTenPlayers;
        }

        public static void SerializePlayerToFile(List<Player> players, string fileName)
        {
            var serializer = new JsonSerializer();
            using (var writer = new StreamWriter(fileName))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, players);
            }

        }

    }
}
