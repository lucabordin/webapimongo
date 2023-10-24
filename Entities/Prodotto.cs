using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Mongo.Entities
{
    public class Prodotto
    {
        //Bson annotations
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String? ProductId { get; set; }
        [BsonElement("ProductName")]
        public string? Nome { get; set; }
        public Categoria Categoria { get; set; }      
        public decimal? UnitPrice { get; set; }
        public int Giacenza { get; set; }

    }


}
