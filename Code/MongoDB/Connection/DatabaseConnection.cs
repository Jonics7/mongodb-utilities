using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Variables;

namespace MongoDB.Connection
{
    public static class DatabaseConnection
    {
        public static void Connect(string mongoConnectionKey, string dbName, string collectionName)
        {
            var mongoClient = new MongoClient(mongoConnectionKey);
            
            var database = mongoClient.GetDatabase(dbName);
            var collection = database.GetCollection<BsonDocument>(collectionName);
            
            DatabaseVariables.SetDatabase(database);
            DatabaseVariables.SetCollection(collection);
        }
    }
}
