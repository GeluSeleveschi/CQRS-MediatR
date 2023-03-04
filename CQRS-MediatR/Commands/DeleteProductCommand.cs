using MediatR;

namespace CQRS_MediatR.Commands
{
    public record DeleteProductCommand(int Id): IRequest<bool>;
}
