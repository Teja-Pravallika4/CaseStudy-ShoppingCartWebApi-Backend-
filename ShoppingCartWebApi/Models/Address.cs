using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCartWebApi.Models
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int AddressId { get; set; }

        [ForeignKey("UserDetails")]
        public int UserId { get; set; }
        public string AddressInfo { get; set; }
        public string City { get; set; }
        public string UserState { get; set; }
        public string Pincode { get; set; }

        public virtual UserDetails UserDetails { get; set; }

    }
}