using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Newtonsoft.Json;
using UnityEngine;

namespace MongoDB.Utilities
{
    public static class Converter
    {
        private class OutputData
        {
            public List<string> Data { get; }

            public OutputData()
            {
                Data = new List<string>();
            }
        }

        private static string Deserialize(string rawJson)
        {
            var data = "{" + rawJson.Substring(rawJson.IndexOf("),") + 2);
            // TODO: remove \ from json (BSON fuck you)
            
            return data;
        }

        public static BsonDocument ConvertToBson(string jsonData)
        {
            return BsonSerializer.Deserialize<BsonDocument>(jsonData);
        }

        public static string ConvertToJson(IEnumerable<BsonDocument> documents)
        {
            var output = new OutputData();
            
            foreach (var document in documents)
            {
                output.Data.Add(Deserialize(document.ToString()));
            }

            // Debug.Log(JsonConvert.SerializeObject(output, Formatting.Indented));
            
            return JsonConvert.SerializeObject(output);
        }
    }
}

