using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using student_courses_mvc.Data;
using student_courses_mvc.Models;

namespace student_courses_mvc.Controllers
{
    public class CourseStudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseStudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CourseStudents
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CourseStudent.Include(c => c.Course).Include(c => c.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CourseStudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CourseStudent == null)
            {
                return NotFound();
            }

            var courseStudent = await _context.CourseStudent
                .Include(c => c.Course)
                .Include(c => c.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseStudent == null)
            {
                return NotFound();
            }

            return View(courseStudent);
        }

        // GET: CourseStudents/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id");
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Name");
            return View();
        }

        // POST: CourseStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,CourseId")] CourseStudent courseStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", courseStudent.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Name", courseStudent.StudentId);
            return View(courseStudent);
        }

        // GET: CourseStudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CourseStudent == null)
            {
                return NotFound();
            }

            var courseStudent = await _context.CourseStudent.FindAsync(id);
            if (courseStudent == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", courseStudent.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Name", courseStudent.StudentId);
            return View(courseStudent);
        }

        // POST: CourseStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,CourseId")] CourseStudent courseStudent)
        {
            if (id != courseStudent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseStudentExists(courseStudent.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", courseStudent.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Name", courseStudent.StudentId);
            return View(courseStudent);
        }

        // GET: CourseStudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CourseStudent == null)
            {
                return NotFound();
            }

            var courseStudent = await _context.CourseStudent
                .Include(c => c.Course)
                .Include(c => c.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseStudent == null)
            {
                return NotFound();
            }

            return View(courseStudent);
        }

        // POST: CourseStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CourseStudent == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CourseStudent'  is null.");
            }
            var courseStudent = await _context.CourseStudent.FindAsync(id);
            if (courseStudent != null)
            {
                _context.CourseStudent.Remove(courseStudent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseStudentExists(int id)
        {
          return _context.CourseStudent.Any(e => e.Id == id);
        }
    }
}
