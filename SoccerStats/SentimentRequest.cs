﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerStats
{

    public class SentimentRequest
    {
        [JsonProperty(PropertyName = "documents")]
        public List<Document> Documents { get; set; }
    }

    public class Document
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }

}
