using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerStats
{



    public class SentimentResponse
    {
        [JsonProperty(PropertyName = "documents")]
        public List<Sentiment> Documents { get; set; }
        public object[] errors { get; set; }
    }

    public class Sentiment
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "score")]
        public double Score { get; set; }
    }



}
