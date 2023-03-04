using CQRS_MediatR.Commands;
using CQRS_MediatR.DTOs;
using CQRS_MediatR.Handlers;
using CQRS_MediatR.Notifications;
using CQRS_MediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IPublisher _publisher;

        public ProductsController(ISender sender, IPublisher publisher)
        {
            _sender = sender;
            _publisher = publisher;
        }

        [HttpGet]
        public async Task<ActionResult> GetProductsAsync()
        {
            var products = await _sender.Send(new GetProductsQuery());

            return products != null && products.Any() ? Ok(products) : NoContent();
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductByIdAsync(int id)
        {
            var product = await _sender.Send(new GetProductsByIdQuery(id));

            return product != null ? Ok(product) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> AddProductAsync([FromBody] ProductDto productDto)
        {
            var product = await _sender.Send(new AddProductCommand(productDto));

            await _publisher.Publish(new ProductAddedNotifications(product));

            return CreatedAtRoute("GetProductById", new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProductAsync(int id, [FromBody] ProductDto productDto)
        {
            var product = await _sender.Send(new UpdateProductCommand(id, productDto));

            return product != null ? Ok(product) : StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductAsync(int id)
        {
            var productSuccessfullyDeleted = await _sender.Send(new DeleteProductCommand(id));

            return Ok(productSuccessfullyDeleted);
        }
    }
}
