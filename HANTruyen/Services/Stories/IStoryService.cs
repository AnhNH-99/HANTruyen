using HANTruyen.Models.Entities;
using HANTruyen.ViewModels.Stories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANTruyen.Services.Stories
{
    public interface IStoryService
    {
        public Task<List<StoryViewModel>> GetListStoryAsync();
        public Task<StoryViewModel> GetStoryByIdAsync(int id);
        public Task CreateStoryAsync(StoryCreateViewModel story);
        public Task UpdateStoryAsync(StoryEditViewModel story);
        public Task<Boolean> StoryExists(int id);
        public Task DeleteStoryAsync(int id);
    }
}
