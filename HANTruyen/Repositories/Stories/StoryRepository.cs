using HANTruyen.Models.EF;
using HANTruyen.Models.Entities;
using HANTruyen.ViewModels.Stories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANTruyen.Repositories.Stories
{
    public class StoryRepository : IStoryRepository
    {
        private readonly HANTruyenDbContext _context;
        public StoryRepository(HANTruyenDbContext context)
        {
            _context = context;
        }

        public async Task CreateStoryAsync(Story story)
        {
            _context.Add(story);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStoryAsync(Story story)
        {
            _context.Stories.Remove(story);
            await _context.SaveChangesAsync();
        }

        public async Task<List<StoryViewModel>> GetListStoryAsync()
        {
            return await _context.Stories.Select(x => new StoryViewModel() { 
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

        public async Task<Story> GetStoryByIdAsync(int id)
        {
            return await _context.Stories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> StoryExists(int id)
        {
            return await _context.Stories.AnyAsync(e => e.Id == id);
        }

        public async Task UpdateStoryAsync(Story story)
        {
            _context.Update(story);
            await _context.SaveChangesAsync();
        }
    }
}
