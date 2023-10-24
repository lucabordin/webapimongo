using Microsoft.Extensions.Options;
using Mongo.Entities;
using Mongo.Model;
using MongoDB.Driver;

namespace Mongo.DL
{

    public class MagazzinoContext : IMagazzinoContext
    {
        MagazzinoDatabaseSettings _settings;
        public MagazzinoContext(IOptions<MagazzinoDatabaseSettings> magazzinoDatabaseSettings)
        {
            var client = new MongoClient(magazzinoDatabaseSettings.Value.ConnectionString);
            var database = client.GetDatabase(magazzinoDatabaseSettings.Value.DatabaseName);
            Prodotti = database.GetCollection<Prodotto>(magazzinoDatabaseSettings.Value.CollectionName);
          
        }
        public IMongoCollection<Prodotto> Prodotti { get; }
    }

}
