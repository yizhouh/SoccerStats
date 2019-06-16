﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace SoccerStats
{
    public class WebClientReading
    {
        // Enter a valid subscription key.
        const string accessKey = "your API key";

        /*
         * If you encounter unexpected authorization errors, double-check this value
         * against the endpoint for your Bing Web search instance in your Azure
         * dashboard.
         */
         const string uriBase = "https://api.cognitive.microsoft.com/bing/v7.0/news/search";
         //const string uriBase = "https://api.cognitive.microsoft.com/bing/v5.0/news";
        //const string uriBase = "https://soccerstats.search.windows.net";
        //const string searchTerm = "Microsoft Cognitive Services";


        public WebClientReading()
        {
        }

        public static string GetGoogleHomePage()
        {
            var webClient = new WebClient();
            byte[] webContent = webClient.DownloadData("http://www.google.com");
            webClient.Dispose();


            using (var stream = new MemoryStream(webContent))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        //deserialize json result generated by webclient return results
        public static List<NewsResult> GetNewsForPlayers(string playerName)
        {
            var result = new List<NewsResult>();
            // Construct the search request URI.
            var uriQuery = uriBase + "?q=" + Uri.EscapeDataString(playerName);

            
            using (var webClient = new WebClient())
            {
                var serializer = new JsonSerializer();
                webClient.Headers.Add("Ocp-Apim-Subscription-Key", accessKey);           
                byte[] webContent = webClient.DownloadData(uriQuery);
                using (var stream = new MemoryStream(webContent))
                using(var reader = new StreamReader(stream))
                using(var jsonReader = new JsonTextReader(reader))
                {
                    result = serializer.Deserialize<NewsSearch>(jsonReader).NewsResults;
                }
            }
            return result;
        }


    }
}
