using CQRS_MediatR.Models;
using CQRS_MediatR.Queries;
using CQRS_MediatR.Repositories.RepositoryInterfaces;
using MediatR;

namespace CQRS_MediatR.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsHandler(IProductRepository productRepository) => _productRepository = productRepository;

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
                                                        => await _productRepository.GetAllProductsAsync();
    }
}
