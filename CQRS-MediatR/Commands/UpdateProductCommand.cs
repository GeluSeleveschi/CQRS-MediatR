using CQRS_MediatR.DTOs;
using CQRS_MediatR.Models;
using MediatR;

namespace CQRS_MediatR.Commands
{
    public record UpdateProductCommand(int Id, ProductDto ProductDto) : IRequest<Product>;
}
