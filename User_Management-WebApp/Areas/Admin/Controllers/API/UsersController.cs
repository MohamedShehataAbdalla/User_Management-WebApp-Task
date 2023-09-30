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
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
                throw new Exception();


            return Ok();
        }
    }
}
