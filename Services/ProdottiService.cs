using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Mongo.DL;
using Mongo.Entities;
using Mongo.Model;
using MongoDB.Driver;

namespace Mongo.Services
{
    public class ProdottiService : IProdottiService
    {
        private readonly IMagazzinoContext _context;
        public ProdottiService(IMagazzinoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Prodotto>> GetProdotti()
        {
            return await _context
                            .Prodotti
                            .Find(p => true)
                            .ToListAsync();
        }
        public async Task<Prodotto> GetProdotto(string id)
        {
            return await _context
                           .Prodotti
                           .Find(p => p.ProductId == id)
                           .FirstOrDefaultAsync();
        }
        public async Task<List<Prodotto>> GetProdottiByName(string name)
        {
            FilterDefinition<Prodotto> filter = Builders<Prodotto>.Filter.ElemMatch(p => p.Nome, name);
            return await _context
                             .Prodotti
                             .Find(filter)
                             .ToListAsync();
        }
        public async Task<List<Prodotto>> GetProdottiByCategory(string categoryName)
        {
            FilterDefinition<Prodotto> filter = Builders<Prodotto>.Filter.Eq(p => p.Categoria.CategoryName, categoryName);
            return await _context
                             .Prodotti
                             .Find(filter)
                             .ToListAsync();
        }
        public async Task CreateProdotto(Prodotto product)
        {
            await _context.Prodotti.InsertOneAsync(product);
        }
        public async Task<bool> UpdateProdotto(Prodotto product)
        {
            var updateResult = await _context
                                        .Prodotti
                                        .ReplaceOneAsync(filter: g => g.ProductId == product.ProductId, replacement: product); return updateResult.IsAcknowledged
                     && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> DeleteProdotto(string id)
        {
            FilterDefinition<Prodotto> filter = Builders<Prodotto>.Filter.Eq(p => p.ProductId, id); DeleteResult deleteResult = await _context
                                                 .Prodotti
                                                 .DeleteOneAsync(filter); return deleteResult.IsAcknowledged
                  && deleteResult.DeletedCount > 0;
        }
    }
}





