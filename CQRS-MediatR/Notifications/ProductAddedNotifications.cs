using CQRS_MediatR.Models;
using MediatR;

namespace CQRS_MediatR.Notifications
{
    public record ProductAddedNotifications(Product Product): INotification;
}
