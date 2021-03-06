using Catalog.API.Data.Mongo.Interfaces;
using Catalog.API.Entities;
using Catalog.API.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.API.Data.Mongo
{
    public class CatalogContext: ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }

        public readonly DatabaseOptions _dbOptions;

        public CatalogContext(DatabaseOptions dbOptions)
        {
            _dbOptions = dbOptions;
            var client = new MongoClient(_dbOptions.ConnectionString);
            var database = client.GetDatabase(_dbOptions.DatabaseName);
            Products = database.GetCollection<Product>(_dbOptions.CollectionName);
        }
    }
}
