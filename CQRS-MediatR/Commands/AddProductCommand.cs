using CQRS_MediatR.DTOs;
using CQRS_MediatR.Models;
using MediatR;

namespace CQRS_MediatR.Commands
{
    public record AddProductCommand(ProductDto ProductDto) : IRequest<Product>;
}
