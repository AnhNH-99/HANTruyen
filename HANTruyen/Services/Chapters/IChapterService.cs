using HANTruyen.ViewModels.Chapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANTruyen.Services.Chapters
{
    public interface IChapterService
    {
        public Task<List<ChapterViewModel>> GetListChapterAsync();
        public Task CreateChapterAsync(ChapterCreateViewModel chapter);
        public Task UpdateChapterAsync(ChapterEditViewModel chapter);
        public Task<ChapterViewModel> GetChapterByIdAsync(int id);
    }
}
