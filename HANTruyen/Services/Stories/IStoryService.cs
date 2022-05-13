using HANTruyen.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANTruyen.Services.Stories
{
    public interface IStoryService
    {
        public Task<List<Story>> GetListStoryAsync();
        public Task<Story> GetStoryByIdAsync(int id);
        public Task CreateStoryAsync(Story story);
        public Task UpdateStoryAsync(Story story);
        public Task<Boolean> StoryExists(int id);
        public Task DeleteStoryAsync(int id);
    }
}
