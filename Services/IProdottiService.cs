using Mongo.Entities;

namespace Mongo.Services
{
    public interface IProdottiService
    {
        Task<List<Prodotto>> GetProdotti();
        Task<Prodotto> GetProdotto(string id);
        Task<List<Prodotto>> GetProdottiByName(string name);
        Task<List<Prodotto>> GetProdottiByCategory(string categoryName);
        Task CreateProdotto(Prodotto product);
        Task<bool> UpdateProdotto(Prodotto product);
        Task<bool> DeleteProdotto(string id);
    }

}
