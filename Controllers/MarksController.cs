using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityMarks.Data;
using UniversityMarks.Models;
using System.Threading.Tasks;

namespace UniversityMarks.Controllers
{
    public class MarksController : Controller
    {
        private readonly UniversityContext _context;

        public MarksController(UniversityContext context)
        {
            _context = context;
        }

        // Action to upload marks
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(Mark mark)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mark);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mark);
        }

        // Action to display marks
        public async Task<IActionResult> Index()
        {
            var marks = await _context.Marks.Include(m => m.Student).Include(m => m.Subject).ToListAsync();
            return View(marks);
        }
    }
}
