using CQRS_MediatR.Notifications;
using CQRS_MediatR.Repositories.RepositoryInterfaces;
using MediatR;

namespace CQRS_MediatR.Handlers
{
    public class CacheInvalidationHandler: INotificationHandler<ProductAddedNotifications>
    {
        private readonly IProductRepository _productRepository;

        public CacheInvalidationHandler(IProductRepository productRepository) => _productRepository = productRepository;

        public async Task Handle(ProductAddedNotifications notification, CancellationToken cancellationToken)
        {
            await _productRepository.EventOccured(notification.Product, "Cache Invalidated");
            await Task.CompletedTask;
        }
    }
}
