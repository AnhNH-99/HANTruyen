using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HANTruyen.Models.EF;
using HANTruyen.Models.Entities;
using HANTruyen.Services.Chapters;
using HANTruyen.ViewModels.Chapters;

namespace HANTruyen.Controllers
{
    public class ChapterController : Controller
    {
        private readonly HANTruyenDbContext _context;
        private readonly IChapterService _chapterService;
        public ChapterController(HANTruyenDbContext context, IChapterService chapterService)
        {
            _context = context;
            _chapterService = chapterService;
        }

        // GET: Chapter
        public async Task<IActionResult> Index()
        {
            var chapters = await _chapterService.GetListChapterAsync();
            return View(chapters);
        }

        // GET: Chapter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chapter = await _chapterService.GetChapterByIdAsync((int)id);
            if (chapter == null)
            {
                return NotFound();
            }

            return View(chapter);
        }

        // GET: Chapter/Create
        public IActionResult Create()
        {
            ViewData["StroyId"] = new SelectList(_context.Stories, "Id", "Name");
            return View();
        }

        // POST: Chapter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StroyId,Name,Title,Description")] ChapterCreateViewModel chapter)
        {
            if (ModelState.IsValid)
            {
                await _chapterService.CreateChapterAsync(chapter);
                return RedirectToAction(nameof(Index));
            }
            ViewData["StroyId"] = new SelectList(_context.Stories, "Id", "Name", chapter.StroyId);
            return View(chapter);
        }

        // GET: Chapter/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chapter = await _context.Chapters.FindAsync(id);
            if (chapter == null)
            {
                return NotFound();
            }
            var chapterView = new ChapterEditViewModel()
            {
                Id = chapter.Id,
                StroyId = chapter.StroyId,
                Name = chapter.Name,
                Title = chapter.Title,
                Description = chapter.Description,
                Status = chapter.Status
            };
            ViewData["StroyId"] = new SelectList(_context.Stories, "Id", "Name", chapter.StroyId);
            return View(chapterView);
        }

        // POST: Chapter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StroyId,Name,Title,Description,Status,")] ChapterEditViewModel chapter)
        {
            if (id != chapter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _chapterService.UpdateChapterAsync(chapter);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChapterExists(chapter.Id))
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
            ViewData["StroyId"] = new SelectList(_context.Stories, "Id", "Name", chapter.StroyId);
            return View(chapter);
        }

        // GET: Chapter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chapter = await _context.Chapters
                .Include(c => c.Story)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chapter == null)
            {
                return NotFound();
            }

            return View(chapter);
        }

        // POST: Chapter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chapter = await _context.Chapters.FindAsync(id);
            _context.Chapters.Remove(chapter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChapterExists(int id)
        {
            return _context.Chapters.Any(e => e.Id == id);
        }
    }
}
