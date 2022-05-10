using Catalog.API.Entities;
using Catalog.API.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }

        public readonly DatabaseOptions _dbOptions;

        public CatalogContext(IOptions<DatabaseOptions> dbOptions)
        { 
            _dbOptions = dbOptions.Value;
            var client = new MongoClient(_dbOptions.ConnectionString);
            var database = client.GetDatabase(_dbOptions.DatabaseName);
            Products = database.GetCollection<Product>(_dbOptions.CollectionName);

            CatalogContextSeed.SeedData(Products);
        }
    }
}
