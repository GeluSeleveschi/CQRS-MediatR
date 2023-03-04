using System.ComponentModel.DataAnnotations;

namespace CQRS_MediatR.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
