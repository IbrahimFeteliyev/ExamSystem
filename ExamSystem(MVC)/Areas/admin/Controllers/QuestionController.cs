using ExamSystem_MVC_.Data;
using ExamSystem_MVC_.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamSystem_MVC_.Areas.admin.Controllers
{
    [Area("admin")]
    public class QuestionController : Controller
    {
        private readonly ExamDbContext _context;

        public QuestionController(ExamDbContext context)
        {
            _context = context;
        }

        // GET: QuestionController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Questions.ToListAsync());
        }

        public async Task<IActionResult> Detail(int id)
        {
            var question = _context.Questions.FirstOrDefault(x => x.ID == id);
            if (question == null) return NotFound();
            return View(question);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Subject = _context.Subjects.ToList();    
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
            return RedirectToAction(nameof(Create));
        }

        [HttpGet] 
        public async Task<IActionResult> Edit(int id)
        {

            var question = _context.Questions.Include(x=>x.Subject).FirstOrDefault(x => x.ID == id);
            if (question == null) return NotFound();
            return View(question);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Question question)
        {
            try
            {
                var updatedEntity = _context.Entry(question);
                updatedEntity.State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return NotFound();
            }
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.FirstOrDefaultAsync(m => m.ID == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
