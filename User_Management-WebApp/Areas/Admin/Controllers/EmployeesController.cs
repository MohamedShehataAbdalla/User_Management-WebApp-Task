using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User_Management_WebApp.Constants;

namespace User_Management_WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = Roles.Admin)]
    [Route("Admin/[controller]/[action]")]
    public class EmployeesController : Controller
    {
        [Authorize(Permissions.Employee.View)]
        // GET: EmployeesController
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Permissions.Employee.Details)]
        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize(Permissions.Employee.Create)]
        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Permissions.Employee.Edit)]
        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Permissions.Employee.Delete)]
        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
