using CQRS_MediatR.Models;
using MediatR;

namespace CQRS_MediatR.Queries
{
    public record GetProductsByIdQuery(int Id) : IRequest<Product>;
}
