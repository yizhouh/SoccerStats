using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

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
                var fileContents = DifferentWaysToReadFiles.ReadFile(fileName);

            }
            else
            {
                Console.WriteLine("No file exists");
            }
            //read and deserialize player.json
            fileName = Path.Combine(directory.FullName, "players.json");
            var players = DifferentWaysToReadFiles.DeserializePlayers(fileName);
            var topTen = DifferentWaysToReadFiles.GetTopTenPlayers(players);
            foreach(var player in topTen)
            {
                Console.WriteLine("Name: " + player.FirstName + "PPG：" + player.PointsPerGame);
            }

            //write/serialize topten players to json file
            fileName = Path.Combine(directory.FullName, "topten.json");
            DifferentWaysToReadFiles.SerializePlayerToFile(topTen, fileName);
        }







    }
}
