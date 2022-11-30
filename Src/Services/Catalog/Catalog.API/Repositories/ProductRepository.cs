using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }
        public async Task CreateProduct(Product product)
        {
           await _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(x => x.Id, id);
            var result=await _context.Products.DeleteOneAsync(filter);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

       
        public async Task<Product> GetProduct(string id)
        {
            return await _context.Products.Find(p => p.Id==id).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable< Product>> GetProducts()
        {
            return await _context.Products.Find(p => true).ToListAsync();
        }

     

        public async Task<IEnumerable<Product>> GetProductsByCategory(string category)
        {
            return await _context.Products.Find(p => p.Category==category).ToListAsync();

        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            return await _context.Products.Find(p => p.Category == name).ToListAsync();

        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var result= await _context.Products.ReplaceOneAsync(x=>x.Id==product.Id,product);
            return result.IsAcknowledged&&result.ModifiedCount>0;

        }
    }
}
