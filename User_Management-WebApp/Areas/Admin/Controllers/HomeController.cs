using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace User_Management_WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

    }
}
