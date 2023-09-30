using System.ComponentModel.DataAnnotations;

namespace User_Management_WebApp.Areas.Admin.ViewModels
{
    public class RoleViewModel
    {
        [Required]
        [Display(Name = "Role Name")]
        [DataType(DataType.Text)]
        [StringLength(30)]
        public string Name { get; set; } = string.Empty;
    }
}
