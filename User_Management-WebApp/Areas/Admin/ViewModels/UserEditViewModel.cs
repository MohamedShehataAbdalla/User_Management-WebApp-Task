using System.ComponentModel.DataAnnotations;

namespace User_Management_WebApp.Areas.Admin.ViewModels
{
    public class UserEditViewModel
    {

        [Display(Name = "Id")]
        public string Id { get; set; } = string.Empty;

        [Display(Name = "Username")]
        public string UserName { get; set; } = string.Empty;

        [Display(Name = "Email")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;


        [Display(Name = "Phone Number")]
        [StringLength(11, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 11)]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; } = string.Empty;


        [Display(Name = "First Name")]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string First_Name { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Last_Name { get; set; } = string.Empty;

        [Display(Name = "Bio")]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        [DataType(DataType.MultilineText)]
        public string? Bio { get; set; }

        [Display(Name = "User Image")]
        [DataType(DataType.Upload)]
        public byte[]? Image { get; set; }

        [Display(Name = "Gender")]
        public bool Gender { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateOnly? DateOfBirth { get; set; }

        [Display(Name = "Is Active")]
        public bool Active { get; set; }



    }
}
