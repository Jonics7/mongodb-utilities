using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB.Variables
{
    public static class DatabaseVariables
    {
        private static IMongoDatabase _database;
        private static IMongoCollection<BsonDocument> _collection;

        public static IMongoDatabase GetDatabase() => _database;
        public static void SetDatabase(IMongoDatabase database) => _database = database;
        
        public static IMongoCollection<BsonDocument> Getcollection() => _collection;
        public static void SetCollection(IMongoCollection<BsonDocument> collection) => _collection = collection;
    }
}
