using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace User_Management_WebApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First Name")]
        [MinLength(3), MaxLength(30)]
        [DataType(DataType.Text)]
        public string First_Name { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        [MinLength(3), MaxLength(30)]
        [DataType(DataType.Text)]
        public string Last_Name { get; set; } = string.Empty;

        [Display(Name = "Bio")]
        [MaxLength(255)]
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

        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; }

        [Display(Name = "Created At")]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Updated At")]
        [DataType(DataType.Date)]
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Deleted At")]
        [DataType(DataType.Date)]
        public DateTime? DeletedAt { get; set; }




    }
}
