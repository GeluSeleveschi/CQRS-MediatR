using AutoMapper;
using CQRS_MediatR.Commands;
using CQRS_MediatR.Models;
using CQRS_MediatR.Repositories.RepositoryInterfaces;
using MediatR;

namespace CQRS_MediatR.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public AddProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map(request.ProductDto, new Product());
            await _productRepository.AddProductAsync(product);

            return product;
        }
    }
}
