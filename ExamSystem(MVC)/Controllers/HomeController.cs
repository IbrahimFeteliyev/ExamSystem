using ExamSystem_MVC_.Data;
using ExamSystem_MVC_.Models;
using ExamSystem_MVC_.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExamSystem_MVC_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ExamDbContext _context;

        public HomeController(ILogger<HomeController> logger, ExamDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                Subjects = _context.Subjects.ToList(),
                Questions = _context.Questions.ToList(),


            };
            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}