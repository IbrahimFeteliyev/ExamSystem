using ExamSystem_MVC_.Data;
using ExamSystem_MVC_.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamSystem_MVC_.Areas.admin.Controllers
{
    [Area("admin")]
    public class SubjectController : Controller
    {
        private readonly ExamDbContext _context;

        public SubjectController(ExamDbContext context)
        {
            _context = context;
        }

        // GET: SubjectController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Subjects.ToListAsync());
        }

        // GET: SubjectController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var subject = _context.Subjects.FirstOrDefault(x => x.ID == id);
            if (subject == null) return NotFound();
            return View(subject);
        }

        // GET: SubjectController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: SubjectController/Create
        [HttpPost]
        public async Task<IActionResult> Create(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: SubjectController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var subject = _context.Subjects.FirstOrDefault(x => x.ID == id);
            if (subject == null) return NotFound();
            return View(subject);
        }

        // POST: SubjectController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Subject subject)
        {
            try
            {
                var updatedEntity = _context.Entry(subject);
                updatedEntity.State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        // GET: SubjectController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .FirstOrDefaultAsync(m => m.ID == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: SubjectController/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
