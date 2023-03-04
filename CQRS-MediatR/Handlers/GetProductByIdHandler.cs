using CQRS_MediatR.Models;
using CQRS_MediatR.Queries;
using CQRS_MediatR.Repositories.RepositoryInterfaces;
using MediatR;

namespace CQRS_MediatR.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductsByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdHandler(IProductRepository productRepository) => _productRepository = productRepository;

        public async Task<Product> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
                                                        => await _productRepository.GetProductByIdAsync(request.Id);
    }
}
