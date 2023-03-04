using AutoMapper;
using CQRS_MediatR.Commands;
using CQRS_MediatR.Models;
using CQRS_MediatR.Repositories.RepositoryInterfaces;
using MediatR;

namespace CQRS_MediatR.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.Id);
            
            if (product == null) return null;

            product = _mapper.Map(request.ProductDto, product);
            await _productRepository.UpdateProductAsync(product);

            return product;
        }
    }
}
