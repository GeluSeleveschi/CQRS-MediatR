using CQRS_MediatR.Models;
using MediatR;

namespace CQRS_MediatR.Queries
{
    public record GetProductsQuery : IRequest<IEnumerable<Product>>;
}
