using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ShoppingCartWebApi.Models
{
    public class Product
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string Category { get; set; }

        [DataType("varchar(30)")]
        [Required(ErrorMessage = "Product name cannot be empty")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Product price cannot be empty")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Order> Order { get; set; }



    }
}