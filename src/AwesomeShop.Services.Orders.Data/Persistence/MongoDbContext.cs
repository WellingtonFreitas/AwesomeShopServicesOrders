using AwesomeShop.Services.Orders.Domain.Interfaces.Repositories;
using MongoDB.Driver;

namespace AwesomeShop.Services.Orders.Data.Persistence
{
    public class MongoDbContext : IMongoDBContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDbContext()
        {
            MongoClientSettings mongoClientSettings = MongoClientSettings
                .FromUrl(new MongoUrl("mongodb://admin:password@localhost:27017/admin"));

            mongoClientSettings.SslSettings =
                new SslSettings()
                {
                    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                };

            MongoClient mongoClient = new MongoClient(settings: mongoClientSettings);

            _mongoDatabase = mongoClient.GetDatabase("awesome-shop");
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>(string collection)
        {
            return _mongoDatabase.GetCollection<TEntity>(name: collection);
        }
    }
}