using System.ComponentModel.DataAnnotations;

namespace ShoppingCartWebApi.Models
{
    public class LoginModel
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string EmailId { get; set; }
    }
}
