using HANTruyen.Models.EF;
using HANTruyen.Models.Entities;
using HANTruyen.ViewModels.Chapters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANTruyen.Services.Chapters
{
    public class ChapterService : IChapterService
    {
        private readonly HANTruyenDbContext _context;
        public ChapterService (HANTruyenDbContext context)
        {
            _context = context;
        }
        public async Task CreateChapterAsync(ChapterCreateViewModel body)
        {
            var chapter = new Chapter()
            {
                Name = body.Name,
                Title = body.Title,
                Description = body.Description,
                StroyId = body.StroyId
            };
            _context.Add(chapter);
            await _context.SaveChangesAsync();
        }

        public async Task<ChapterViewModel> GetChapterByIdAsync(int id)
        {
            return await _context.Chapters.Select(x => new ChapterViewModel()
            {
                Id = x.Id,
                StroyId = x.StroyId,
                Name = x.Name,
                Title = x.Title,
                Description = x.Description,
                Status = x.Status,
                Views = x.Views,
                Likes = x.Likes,
                CreatedAt = x.CreatedAt,
                CreatedBy = x.CreatedBy,
                UpdatedAt = x.UpdatedAt,
                UpdatedBy = x.UpdatedBy
            }).Where(y => y.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ChapterViewModel>> GetListChapterAsync()
        {
            return await _context.Chapters.Select(x => new ChapterViewModel()
            {
                Id = x.Id,
                StroyId = x.StroyId,
                Name = x.Name,
                Title = x.Title,
                Description = x.Description,
                Status = x.Status,
                Views = x.Views,
                Likes = x.Likes,
                CreatedAt = x.CreatedAt,
                CreatedBy = x.CreatedBy,
                UpdatedAt = x.UpdatedAt,
                UpdatedBy = x.UpdatedBy
            }).ToListAsync();
        }

        public async Task UpdateChapterAsync(ChapterEditViewModel body)
        {
            var chapter = await _context.Chapters.FirstOrDefaultAsync(x => x.Id == body.Id);
            if (chapter != null)
            {
                chapter.Name = body.Name;
                chapter.Title = body.Title;
                chapter.Description = body.Description;
                chapter.Status = body.Status;
                chapter.StroyId = body.StroyId;
                _context.Update(chapter);
                await _context.SaveChangesAsync();
            }
        }
    }
}
