using System.ComponentModel.DataAnnotations;

namespace NewShopOnline.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter username")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}