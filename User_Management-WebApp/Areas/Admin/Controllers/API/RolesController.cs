using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using User_Management_WebApp.Models;

namespace User_Management_WebApp.Areas.Admin.Controllers.API
{
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Route("Admin/api/[controller]/[action]")]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RolesController(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound();

            var result = await _roleManager.DeleteAsync(role);

            if (!result.Succeeded)
                throw new Exception();


            return Ok();
        }
    }
}
