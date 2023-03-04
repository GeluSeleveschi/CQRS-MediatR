using CQRS_MediatR.Commands;
using CQRS_MediatR.Repositories.RepositoryInterfaces;
using MediatR;

namespace CQRS_MediatR.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository) => _productRepository = productRepository;

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
                                                     => await _productRepository.DeleteProductAsync(request.Id);
    }
}
