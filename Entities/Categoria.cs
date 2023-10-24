using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Mongo.Entities
{
    public class Categoria
    {
        //Bson annotations
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? CategoryId { get; set; }

        public string? CategoryName { get; set; }
        //public string? Descrizione { get; set; }
        //public List<Prodotto> Descrizione { get; set; }
    }

}
