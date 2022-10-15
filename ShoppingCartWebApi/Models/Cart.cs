using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;

namespace ShoppingCartWebApi.Models
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }

        //[ForeignKey("UserDetails")]
       // public int UserId { get; set; }

        //[ForeignKey("Product")]
        //public int ProductId { get; set; }

        //public int Quantity { get; set; } = 1;

        //public int Price { get; set; }

        //public virtual UserDetails UserDetails { get; set; }
        //public virtual Product Product { get; set; }
        //public virtual ICollection<Order> Order { get; set; }



        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }

        public int Quantity { get; set; } = 1;

        public int Price { get; set; }




        //public virtual UserDetails UserDetails { get; set; }
        //public virtual Product Product { get; set; }
        //public virtual ICollection<Order> Order { get; set; }


    }
}