using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ShoppingCartWebApi.Models
{
    public class UserDetails
    {
        public UserDetails()
        {
            Order = new HashSet<Order>();

        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        public string Role { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType("varchar(30)")]
        [Required(ErrorMessage = "Email cannot be empty")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Mobile no. cannot be empty")]
        [MinLength(10)]
        [MaxLength(10)]
        public string MobileNumber { get; set; }

        [Required]
        public string AddressInfo { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string UserState { get; set; }

        [Required]
        public string Pincode { get; set; }

        [Required]
        [StringLength(8, MinimumLength =4, ErrorMessage = "You must specify a password betwwen 4 and 8")]
        public string Password { get; set; }

        [Required]
        public bool IsLogin { get; set; } = false;



        public virtual ICollection<feedback> feedback { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }

    }
}