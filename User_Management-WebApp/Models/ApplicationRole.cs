using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace User_Management_WebApp.Models
{
    public class ApplicationRole : IdentityRole
    {

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
