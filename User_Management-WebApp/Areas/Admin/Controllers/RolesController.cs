using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using User_Management_WebApp.Areas.Admin.ViewModels;
using User_Management_WebApp.Constants;
using User_Management_WebApp.Models;

namespace User_Management_WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Roles.SuperAdmin)]
    [Route("Admin/[controller]/[action]")]
    public class RolesController : Controller
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RolesController(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        // GET: RolesController
        public async Task<ActionResult> Index()
        {
            var roles = await _roleManager.Roles.Where(x => x.DeletedAt == null).ToListAsync();
            var viewModel = roles.Select(role => new RoleViewModel 
            {
                Id = role.Id,
                Name = role.Name!, 
                Active = role.Active 
            }).ToList();

            return View(viewModel);
        }

        public async Task<IActionResult> Archive()
        {
            var roles = await _roleManager.Roles.Where(x => x.DeletedAt != null).ToListAsync();
            var viewModel = roles.Select(role => new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name!,
                Active = role.Active
            }).ToList();

            return View(viewModel);
        }

        // GET: RolesController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound();

            var viewModel = new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name!,
                Active = role.Active,
                DeletedAt = role.DeletedAt,
                CreatedAt = role.CreatedAt,
                UpdatedAt = role.UpdatedAt,
                CreatedBy = role.CreatedBy,
            };

            return View(viewModel);
        }

        // POST: RolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RoleFormViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) 
                    return View(nameof(Index), await _roleManager.Roles.ToListAsync());

                if (await _roleManager.RoleExistsAsync(model.Name))
                {
                    ModelState.AddModelError("Name", "This Name Already Exists!");
                    return View(nameof(Index), await _roleManager.Roles.ToListAsync());
                }

                var result =  await _roleManager.CreateAsync(new ApplicationRole { Name = model.Name.Trim(), Active = model.Active, CreatedBy = User.Identity!.Name });

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("Name", error.Description);
                    }
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index), await _roleManager.Roles.ToListAsync());
            }
            
        }

        // POST: RolesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, RoleFormViewModel model)
        {
            try
            {

                var user = await _roleManager.FindByIdAsync(id);
                if (user == null)
                    return NotFound();

                if (!ModelState.IsValid)
                    return View(nameof(Index), await _roleManager.Roles.ToListAsync());


                if (await _roleManager.RoleExistsAsync(model.Name) && user.Id != model.Id)
                {
                    ModelState.AddModelError("Name", "This Name Already Exists!");
                    return View(nameof(Index), await _roleManager.Roles.ToListAsync());
                }

                var result = await _roleManager.UpdateAsync(new ApplicationRole { Name = model.Name.Trim(), Active = model.Active, UpdatedAt = DateTime.Now });

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("Name", error.Description);
                    }
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index), await _roleManager.Roles.ToListAsync());
            }
        }

        // GET: RolesController/SoftDelete/5
        public async Task<ActionResult> SoftDelete(string id)
        {
            var user = await _roleManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            var viewModel = new RoleViewModel
            {
                Id = user.Id,
                Name = user.Name!,
            };

            return View(viewModel);
        }

        // POST: RolesController/SoftDelete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SoftDelete(string id, RoleViewModel model)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(model.Id);
                if (role == null)
                    return NotFound();

                role.DeletedAt = DateTime.Now;

                var result = await _roleManager.UpdateAsync(role);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("Name", error.Description);
                    }
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: RolesController/SoftDelete/5
        public async Task<ActionResult> Restore(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound();

            var viewModel = new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name!,
            };

            return View(viewModel);
        }

        // POST: RolesController/SoftDelete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Restore(string id, RoleViewModel model)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(model.Id);
                if (role == null)
                    return NotFound();

                role.DeletedAt = null;

                var result = await _roleManager.UpdateAsync(role);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("Name", error.Description);
                    }
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        public async Task<IActionResult> ManagePermissions(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound();

            var roleClaims = _roleManager.GetClaimsAsync(role).Result.Select(c => c.Value).ToList();
            var allClaims = Permissions.GenerateAllPermitions();
            var allPermissions = allClaims.Select(p => new ListCheckBoxViewModel { DisplayValue = p}).ToList();

            foreach (var Permission in allPermissions)
            {
                if (roleClaims.Any(c => c == Permission.DisplayValue))
                    Permission.IsSelected = true;
            }

            var viewModel = new RolePermissionsViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name!,
                RoleCalims = allPermissions,
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManagePermissions(RolePermissionsViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            if (role == null)
                return NotFound();

            var roleClaims = await _roleManager.GetClaimsAsync(role);

            foreach (var claim in model.RoleCalims!)
            {
                if (roleClaims.Any(x => x.Value == claim.DisplayValue) && !claim.IsSelected)
                    await _roleManager.RemoveClaimAsync(role, new Claim(Constants.ClaimPermationTypes.Permations.ToString(), claim.DisplayValue));

                if (!roleClaims.Any(x => x.Value == claim.DisplayValue) && claim.IsSelected)
                    await _roleManager.AddClaimAsync(role, new Claim(Constants.ClaimPermationTypes.Permations.ToString(), claim.DisplayValue));
            }


            return RedirectToAction(nameof(Index));
        }
    }
}
