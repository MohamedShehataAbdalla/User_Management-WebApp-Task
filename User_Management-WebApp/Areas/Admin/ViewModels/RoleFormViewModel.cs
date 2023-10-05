using System.ComponentModel.DataAnnotations;

namespace User_Management_WebApp.Areas.Admin.ViewModels
{
    public class RoleFormViewModel
    {
        [Display(Name = "Id")]
        public string Id { get; set; } = string.Empty;

        [Display(Name = "Role Name")]
        [DataType(DataType.Text)]
        [StringLength(30)]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Is Active")]
        public bool Active { get; set; }
    }
}
