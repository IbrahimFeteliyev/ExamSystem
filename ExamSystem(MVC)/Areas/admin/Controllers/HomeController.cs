using Microsoft.AspNetCore.Mvc;

namespace ExamSystem_MVC_.Areas.admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
