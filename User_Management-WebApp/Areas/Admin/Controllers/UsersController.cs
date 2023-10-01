using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using User_Management_WebApp.Areas.Admin.ViewModels;
using User_Management_WebApp.Models;

namespace User_Management_WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Route("Admin/[controller]/[action]")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        // GET: UsersController
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.Where(x => x.DeletedAt == null).ToListAsync();

            var userViewModels = users.Select(user => new UserViewModel
            {
                Id = user.Id,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender,
                DateOfBirth = user.DateOfBirth,
                Bio = user.Bio,
                Image = user.Image,
                UserName = user.UserName!,
                Active = user.Active,
                RolesName = _userManager.GetRolesAsync(user).Result,
            }).ToList();

            return View(userViewModels);
        }

        public async Task<IActionResult> Archive()
        {
            var users = await _userManager.Users.Where(x => x.DeletedAt != null).ToListAsync();

            var userViewModels = users.Select(user => new UserViewModel
            {
                Id = user.Id,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender,
                DateOfBirth = user.DateOfBirth,
                Bio = user.Bio,
                Image = user.Image,
                UserName = user.UserName!,
                Active = user.Active,
                DeletedAt = user.DeletedAt,
                RolesName = _userManager.GetRolesAsync(user).Result,
            }).ToList();

            return View(userViewModels);
        }

        // GET: UsersController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            var viewModel = new UserViewModel
            {
                Id = user.Id,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender,
                DateOfBirth = user.DateOfBirth,
                Bio = user.Bio,
                Image = user.Image,
                UserName = user.UserName!,
                Active = user.Active,
                DeletedAt = user.DeletedAt,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                CreatedBy = user.CreatedBy,
                RolesName = _userManager.GetRolesAsync(user).Result,
            };

            return View(viewModel);
        }

        // GET: UsersController/Create
        public async Task<ActionResult> Create()
        {
            var roles = await _roleManager.Roles.Select(r => new RoleListViewModel { RoleId = r.Id, RoleName = r.Name }).ToListAsync();

            var viewModel = new UserCreateViewModel
            {
                Roles = roles,
            };

            return View(viewModel);
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserCreateViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                if (!model.Roles.Any(r => r.IsSelected))
                {
                    ModelState.AddModelError("Roles", "Please select at least one role");
                    return View(model);
                }

                if (await _userManager.FindByEmailAsync(model.Email) != null)
                {
                    ModelState.AddModelError("Email", "Email is already exists");
                    return View(model);
                }

                if (await _userManager.FindByNameAsync(model.UserName) != null)
                {
                    ModelState.AddModelError("UserName", "Username is already exists");
                    return View(model);
                }

                var user = new ApplicationUser();

                if (Request.Form.Files.Count > 0)
                {
                    var image = Request.Form.Files.FirstOrDefault();

                    var allowedExtentions = new List<string> { ".jpg", ".jpeg", ".png", ".webp", ".tiff", ".tif", ".bmp" };

                    if (!allowedExtentions.Contains(Path.GetExtension(image.FileName.ToLower())))
                    {
                        ModelState.AddModelError("Image", $"Only {string.Join(" ,", allowedExtentions)} are allowed!");
                        return View(model);
                    }

                    int maxLength = 1_048_576;
                    if (image.Length > maxLength)
                    {
                        ModelState.AddModelError("Image", $"Profile image cannot be more than 1 MB!");
                        return View(model);
                    }

                    using var dataStream = new MemoryStream();
                    await image.CopyToAsync(dataStream);

                    user.Image = dataStream.ToArray();
                }


                user.First_Name = model.First_Name;
                user.Last_Name = model.Last_Name;
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.PhoneNumber = model.PhoneNumber;
                user.Gender = model.Gender;
                user.DateOfBirth = model.DateOfBirth;
                user.Bio = model.Bio;
                user.Active = model.Active;
                user.CreatedBy = User.Identity.Name;



                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("Bio", error.Description);
                    }
                    return View(model);
                }

                await _userManager.AddToRolesAsync(user, model.Roles.Where(r => r.IsSelected).Select(r => r.RoleName));


                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View(model);
            }
          
        }

        // GET: UsersController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();


            var viewModel = new UserEditViewModel
            {
                Id = id,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                DateOfBirth = (DateOnly)user.DateOfBirth,
                Gender = user.Gender,
                Bio = user.Bio,
                Image = user.Image,
                Active = user.Active,
            };

            return View(viewModel);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserEditViewModel model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if (user == null)
                    return NotFound();

                if(!ModelState.IsValid)
                    return View(model);

                var userWithSameEmail = await _userManager.FindByEmailAsync(model.Email);
                if (userWithSameEmail != null && userWithSameEmail.Id != model.Id)
                {
                    ModelState.AddModelError("Email", "The email is already assiged to another user");
                    return View(model);
                }

                var userWithSameUsername = await _userManager.FindByNameAsync(model.UserName);
                if (userWithSameUsername != null && userWithSameUsername.Id != model.Id)
                {
                    ModelState.AddModelError("UserName", "The username is already assiged to another user");
                    return View(model);
                }

                if (Request.Form.Files.Count > 0)
                {
                    var image = Request.Form.Files.FirstOrDefault();

                    var allowedExtentions = new List<string> { ".jpg", ".jpeg", ".png", ".webp", ".tiff", ".tif", ".bmp" };

                    if (!allowedExtentions.Contains(Path.GetExtension(image.FileName.ToLower())))
                    {
                        ModelState.AddModelError("Image", $"Only {string.Join(" ,", allowedExtentions)} are allowed!");
                        return View(model);
                    }

                    int maxLength = 1_048_576;
                    if (image.Length > maxLength)
                    {
                        ModelState.AddModelError("Image", $"Profile image cannot be more than 1 MB!");
                        return View(model);
                    }

                    using var dataStream = new MemoryStream();
                    await image.CopyToAsync(dataStream);

                    user.Image = dataStream.ToArray();
                }


                user.First_Name = model.First_Name;
                user.Last_Name = model.Last_Name;
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.PhoneNumber = model.PhoneNumber;
                user.Gender = model.Gender;
                user.DateOfBirth = model.DateOfBirth;
                user.Bio = model.Bio;
                user.Active = model.Active;
                user.UpdatedAt = DateTime.Now;

                var result = await _userManager.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("Bio", error.Description);
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

        // GET: UsersController/SoftDelete/5
        public async Task<ActionResult> SoftDelete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            var viewModel = new UserViewModel
            {
                Id = user.Id,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                UserName = user.UserName!,
            };

            return View(viewModel);
        }

        // POST: UsersController/SoftDelete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SoftDelete(string id, UserViewModel model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if (user == null)
                    return NotFound();

                user.DeletedAt = DateTime.Now;

                var result = await _userManager.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("UserName", error.Description);
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

        // GET: UsersController/SoftDelete/5
        public async Task<ActionResult> Restore(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            var viewModel = new UserViewModel
            {
                Id = user.Id,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                UserName = user.UserName!,
            };

            return View(viewModel);
        }

        // POST: UsersController/SoftDelete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Restore(string id, UserViewModel model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if (user == null)
                    return NotFound();

                user.DeletedAt = null;

                var result = await _userManager.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("UserName", error.Description);
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

        // GET: UsersController/ChangePassword/5
        public async Task<ActionResult> ChangePassword(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            var viewModel = new UserViewModel
            {
                Id = user.Id,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                UserName = user.UserName!,
            };

            return View(viewModel);
        }

        // POST: UsersController/ChangePassword/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(string id, UserViewModel model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if (user == null)
                    return NotFound();

                user.UpdatedAt = DateTime.Now;

                _userManager.RemovePasswordAsync(user);

                var result = await  _userManager.AddPasswordAsync(user, model.Password);

            if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("UserName", error.Description);
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

        public async Task<IActionResult> ManageRoles(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            var roles = await _roleManager.Roles.ToListAsync();

            var viewModel = new UserRolesViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = roles.Select(role => new RoleListViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    IsSelected = _userManager.IsInRoleAsync(user, role.Name).Result,
                }).ToList(),
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageRoles(UserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return NotFound();

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var role in model.Roles)
            {
                if (userRoles.Any(x => x == role.RoleName) && !role.IsSelected)
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);

                if (!userRoles.Any(x => x == role.RoleName) && role.IsSelected)
                    await _userManager.AddToRoleAsync(user, role.RoleName);
            }

            user.UpdatedAt = DateTime.Now;

            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Index));
        }
    }
}
