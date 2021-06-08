using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Utilities;
using MongoDB.Variables;

namespace MongoDB.API
{
    public static class API
    {
        private static readonly IMongoCollection<BsonDocument> Collection = DatabaseVariables.Getcollection();
        public static async void SendData(string jsonData)
        {
            var data = Converter.ConvertToBson(jsonData);
            await Collection.InsertOneAsync(data);
        }

        public static async Task<string> GetData()
        {
            var data = Collection.FindAsync(new BsonDocument());
            var dataAwaited = await data;

            var documentsList = dataAwaited.ToList();
            
            return Converter.ConvertToJson(documentsList);
        }

        public static async void DeleteAllData()
        {
            await Collection.DeleteManyAsync(new BsonDocument());
        }
    }
}
