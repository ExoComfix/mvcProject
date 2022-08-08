using System.ComponentModel.DataAnnotations;

namespace mvcProjectvs.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

