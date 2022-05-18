using HANTruyen.Models.EF;
using HANTruyen.Models.Entities;
using HANTruyen.ViewModels.Stories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANTruyen.Services.Stories
{
    public class StoryService : IStoryService
    {
        private readonly HANTruyenDbContext _context;
        public StoryService(HANTruyenDbContext context)
        {
            _context = context;
        }

        public async Task CreateStoryAsync(StoryCreateViewModel request)
        {
            var story = new Story()
            {
                Name = request.Name,
                Title = request.Title,
                Description = request.Description,
                Author = request.Author
            };
            await _context.AddAsync(story);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStoryAsync(int id)
        {
            var story = await _context.Stories.FirstOrDefaultAsync(x => x.Id == id);
            _context.Stories.Remove(story);
            await _context.SaveChangesAsync();
        }

        public async Task<List<StoryViewModel>> GetListStoryAsync()
        {
            return await _context.Stories.Select(x => new StoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Title = x.Title,
                Description = x.Description,
                Author = x.Author,
                Views = x.Views,
                Likes = x.Likes,
                Follows = x.Follows,
                CreatedAt = x.CreatedAt,
                CreatedBy = x.CreatedBy,
                UpdatedAt = x.UpdatedAt,
                UpdatedBy = x.UpdatedBy
            }).ToListAsync();
        }

        public async Task<StoryViewModel> GetStoryByIdAsync(int id)
        {
            var story = await _context.Stories.FirstOrDefaultAsync(x => x.Id == id);
            var storyView = new StoryViewModel();
            if (story != null)
            {
                storyView.Id = story.Id;
                storyView.Name = story.Name;
                storyView.Title = story.Title;
                storyView.Description = story.Description;
                storyView.Status = story.Status;
                storyView.Author = story.Author;
                storyView.Views = story.Views;
                storyView.Likes = story.Likes;
                storyView.Follows = story.Follows;
                storyView.CreatedAt = story.CreatedAt;
                storyView.CreatedBy = story.CreatedBy;
                storyView.UpdatedAt = story.UpdatedAt;
                storyView.UpdatedBy = story.UpdatedBy;
            }
            return storyView;
        }

        public async Task<bool> StoryExists(int id)
        {
            return await _context.Stories.AnyAsync(e => e.Id == id);
        }

        public async Task UpdateStoryAsync(StoryEditViewModel request)
        {
            var story = await _context.Stories.FirstOrDefaultAsync(x => x.Id == request.Id);
            story.Name = request.Name;
            story.Title = request.Title;
            story.Description = request.Description;
            story.Status = request.Status;
            story.Author = request.Author;
            _context.Update(story);
            await _context.SaveChangesAsync();
        }
    }
}
