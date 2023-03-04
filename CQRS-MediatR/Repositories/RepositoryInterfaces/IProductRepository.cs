using CQRS_MediatR.Models;

namespace CQRS_MediatR.Repositories.RepositoryInterfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task EventOccured(Product product, string evt);
        Task<bool> DeleteProductAsync(int id);
    }
}
