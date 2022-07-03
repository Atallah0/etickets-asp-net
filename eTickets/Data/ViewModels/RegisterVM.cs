using System.ComponentModel.DataAnnotations;

namespace eTickets.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required!")]
        public string fullName { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required!")]
        public string emailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password is required!")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Password don't match!")]
        public string confirmPassword { get; set; }
    }
}
