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
            //string currentDirectory = Directory.GetCurrentDirectory();
            //DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            //var fileName = Path.Combine(directory.FullName, "SoccerGameResults.csv");
            //var file = new FileInfo(fileName);
            //if (file.Exists)
            //{
            //    var fileContents = DifferentWaysToReadFiles.ReadFile(fileName);

            //}
            //else
            //{
            //    Console.WriteLine("No file exists");
            //}
            ////read and deserialize player.json
            //fileName = Path.Combine(directory.FullName, "players.json");
            //var players = DifferentWaysToReadFiles.DeserializePlayers(fileName);
            //var topTen = DifferentWaysToReadFiles.GetTopTenPlayers(players);
            //foreach(var player in topTen)
            //{
            //    Console.WriteLine("Name: " + player.FirstName + "PPG：" + player.PointsPerGame);
            //}

            ////write/serialize topten players to json file
            //fileName = Path.Combine(directory.FullName, "topten.json");
            //DifferentWaysToReadFiles.SerializePlayerToFile(topTen, fileName);

            //var readWebContentWeb = WebClientReading.GetGoogleHomePage();
            //Console.WriteLine(readWebContentWeb);

            var searchResult = WebClientReading.GetNewsForPlayers("Christiano Ronaldo");
            foreach(var i in searchResult)
            {
                Console.WriteLine(string.Format("Date: {0:f}, HeadLine: {1}, Description: {2} \r\n", i.DatePublished, i.Headline, i.Summary));
                Console.ReadKey();

            }
        }







    }
}
