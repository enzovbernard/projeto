using Microsoft.Extensions.Options;
using MongoCrudApiAula06.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoCrudApiAula06.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<GameStoreDatabaseSettings> settings)
        {
            //Config do nosso projeto
            var mongoSettings = MongoClientSettings.FromConnectionString(settings.Value.ConnectionString);

            //Versionamento de Api
            mongoSettings.ServerApi = new ServerApi(ServerApiVersion.V1);

            //Instancia do nosso mongo
            var client = new MongoClient(mongoSettings);

            try
            {
                var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to MongoDB: {ex.Message}");
            }

            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        // Trás qualquer coleção do banco de dados, passando o nome da coleção como parâmetro e o tipo de dado que queremos manipular.
        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }

    }
}