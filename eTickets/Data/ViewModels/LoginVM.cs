using System.ComponentModel.DataAnnotations;

namespace eTickets.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required!")]
        public string emailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
