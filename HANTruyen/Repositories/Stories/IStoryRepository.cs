using HANTruyen.Models.Entities;
using HANTruyen.ViewModels.Stories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANTruyen.Repositories.Stories
{
    public interface IStoryRepository
    {
        public Task<List<StoryViewModel>> GetListStoryAsync();
        public Task<Story> GetStoryByIdAsync(int id);
        public Task<Boolean> StoryExists(int id);
        public Task CreateStoryAsync(Story story);
        public Task UpdateStoryAsync(Story story);
        public Task DeleteStoryAsync(Story story);
    }
}
