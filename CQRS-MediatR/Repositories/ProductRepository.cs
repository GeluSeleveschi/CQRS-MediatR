using CQRS_MediatR.Models;
using CQRS_MediatR.Repositories.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace CQRS_MediatR.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var products = await _dbContext.Products.ToListAsync();

            return await Task.FromResult(products);
        }

        public async Task<Product> GetProductByIdAsync(int id)
                     => await Task.FromResult(await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id));
        public async Task AddProductAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            await Task.CompletedTask;
        }

        public async Task EventOccured(Product product, string evt)
        {
            var existingProduct = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == product.Id);
            if (existingProduct != null)
                existingProduct.Name = $"{product.Name} evt: {evt}";

            await Task.CompletedTask;
        }

        public async Task UpdateProductAsync(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();

            await Task.CompletedTask;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var successfullyDeleted = false;
            var product = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
                successfullyDeleted = true;
            }

            await Task.CompletedTask;
            return successfullyDeleted;
        }
    }
}
