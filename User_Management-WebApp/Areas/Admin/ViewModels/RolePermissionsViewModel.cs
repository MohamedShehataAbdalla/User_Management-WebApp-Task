namespace User_Management_WebApp.Areas.Admin.ViewModels
{
    public class RolePermissionsViewModel
    {
        public string RoleId { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public List<ListCheckBoxViewModel>? RoleCalims { get; set; }
    }
}
