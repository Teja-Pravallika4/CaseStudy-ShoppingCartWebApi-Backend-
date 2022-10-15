using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCartWebApi.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }
        public decimal TransactionAmount { get; set; }

        [ForeignKey("UserDetails")]
        public int UserId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public string Mode { get; set; }
        public int CardNumber { get; set; }

        public virtual UserDetails UserDetails { get; set; }
        public virtual Order Order { get; set; }

    }
}