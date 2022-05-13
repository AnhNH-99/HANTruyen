using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HANTruyen.Models.EF;
using HANTruyen.Models.Entities;
using HANTruyen.Services.Stories;

namespace HANTruyen.Controllers
{
    public class StoryController : Controller
    {
        private readonly HANTruyenDbContext _context;
        private readonly IStoryService _storyService;
        public StoryController(HANTruyenDbContext context, IStoryService storyService)
        {
            _context = context;
            _storyService = storyService;
        }

        // GET: Story
        public async Task<IActionResult> Index()
        {
            return View(await _storyService.GetListStoryAsync());
        }

        // GET: Story/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var story = await _storyService.GetStoryByIdAsync((int)id);
            if (story == null)
            {
                return NotFound();
            }

            return View(story);
        }

        // GET: Story/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Story/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Title,Description,Status,Author,Views,Follows,Likes,CreatedAt,UpdatedAt,CreatedBy,UpdatedBy,DeletedFlag")] Story story)
        {
            if (ModelState.IsValid)
            {
                await _storyService.CreateStoryAsync(story);
                return RedirectToAction(nameof(Index));
            }
            return View(story);
        }

        // GET: Story/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var story = await _storyService.GetStoryByIdAsync((int) id);
            if (story == null)
            {
                return NotFound();
            }
            return View(story);
        }

        // POST: Story/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Title,Description,Status,Author,Views,Follows,Likes,CreatedAt,UpdatedAt,CreatedBy,UpdatedBy,DeletedFlag")] Story story)
        {
            if (id != story.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _storyService.UpdateStoryAsync(story);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _storyService.StoryExists(story.Id))
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
            return View(story);
        }

        // GET: Story/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var story = await _storyService.GetStoryByIdAsync((int)id);
            if (story == null)
            {
                return NotFound();
            }

            return View(story);
        }

        // POST: Story/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _storyService.DeleteStoryAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
