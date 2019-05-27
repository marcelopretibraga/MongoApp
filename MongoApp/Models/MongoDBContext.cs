using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoApp.Models
{
    public class MongoDBContext
    {
        private IMongoDatabase _database { get; }

        public MongoDBContext()
        {
            MongoClientSettings settings =
                MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost:27017"));
            var mongoClient = new MongoClient(settings);
            _database = mongoClient.GetDatabase("servidores");
        }

        public IMongoCollection<Servidor> Servidores
        {
            get
            {
                //Recupera colection de documents
                return _database.GetCollection<Servidor>("servidor");
            }
        }

    }
}
