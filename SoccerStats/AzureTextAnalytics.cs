using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SoccerStats
{
    public class AzureTextAnalytics
    {
        public AzureTextAnalytics()
        {

        }

        public static SentimentResponse GetSentimentResponse(List<NewsResult> newsResults)
        {
            var sentimentResponse = new SentimentResponse();
            var sentimentRequest = new SentimentRequest();
            sentimentRequest.Documents = new List<Document>();
            foreach(var result in newsResults)
            {
                sentimentRequest.Documents.Add(new Document { Id = result.Headline, Text = result.Summary }); 
            }

            using(var webClient = new WebClient())
            {
                //string queryString = null;
                var uri = "https://australiaeast.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment";
                webClient.Headers.Add("Ocp-Apim-Subscription-Key", Constants.TextAnalyticAccessKey);
                webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");
                webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                string requestJson = JsonConvert.SerializeObject(sentimentRequest);
                byte[] requestByte = Encoding.UTF8.GetBytes(requestJson);
                byte[] response = webClient.UploadData(uri, requestByte);

                string sentiments = Encoding.UTF8.GetString(response);
                sentimentResponse = JsonConvert.DeserializeObject<SentimentResponse>(sentiments);
            }
            return sentimentResponse;
        }
    }
}
