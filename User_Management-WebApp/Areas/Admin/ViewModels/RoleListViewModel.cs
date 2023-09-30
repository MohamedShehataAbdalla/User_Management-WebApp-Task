namespace User_Management_WebApp.Areas.Admin.ViewModels
{
    public partial class RoleListViewModel
    {
        public string RoleId { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public bool IsSelected { get; set; }
    }
}
