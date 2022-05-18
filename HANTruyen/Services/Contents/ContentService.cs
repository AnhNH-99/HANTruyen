
using HANTruyen.Models.EF;
using HANTruyen.Models.Entities;
using HANTruyen.ViewModels.Contents;
using System.IO;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HANTruyen.Services.Contents
{
    public class ContentService : IContentService
    {
        private readonly HANTruyenDbContext _context;
        public ContentService(HANTruyenDbContext context)
        {
            _context = context;
        }

        public string ConvertImageToBase64(IFormFile file)
        {
            string baseStr = null;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                baseStr = Convert.ToBase64String(fileBytes);
            }

            return baseStr;
        }

        public async Task CreateContentAsync(ContentCreateViewModel body)
        {
            var content = new Content()
            {
                Name = body.Name,
                ChapterId = body.ChapterId,
                BaseImage = ConvertImageToBase64(body.FileUpload)
            };
            await _context.AddAsync(content);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ContentViewModel>> GetListContentAsync()
        {
            return await _context.Contents.Select(x => new ContentViewModel() { 
                Id = x.Id,
                ChapterId = x.ChapterId,
                Name = x.Name,
                BaseImage = x.BaseImage,
                CreatedAt = x.CreatedAt,
                CreatedBy = x.CreatedBy,
                UpdatedAt = x.UpdatedAt,
                UpdatedBy = x.UpdatedBy
            }).ToListAsync();
        }
    }
}
