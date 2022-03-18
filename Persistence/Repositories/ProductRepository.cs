using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _productContext;
        public ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productContext.Products.ToListAsync();
        }
        public async Task<Product> GetById(int? id)
        {
            return await _productContext.Products.FindAsync(id);
        }
        public async Task<Product> Create(Product product)
        {
            _productContext.Add(product);
            var result = await _productContext.SaveChangesAsync();
            return product;
        }
        public async Task<Product> Update(Product product)
        {
            _productContext.Update(product);
            await _productContext.SaveChangesAsync();
            return product;
        }
        public async Task<Product> Remove(Product product)
        {
            _productContext.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;
        }
    }
}
