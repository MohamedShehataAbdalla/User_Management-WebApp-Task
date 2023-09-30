namespace User_Management_WebApp.Areas.Admin.ViewModels
{
    public partial class UserRolesViewModel
    {

        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public List<RoleListViewModel> Roles { get; set; }
    }
}
