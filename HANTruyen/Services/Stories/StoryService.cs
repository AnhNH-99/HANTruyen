using HANTruyen.Models.Entities;
using HANTruyen.Repositories.Stories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANTruyen.Services.Stories
{
    public class StoryService : IStoryService
    {
        IStoryRepository _storyRepository;
        public StoryService(IStoryRepository storyRepository)
        {
            _storyRepository = storyRepository;
        }

        public async Task CreateStoryAsync(Story story)
        {
            await _storyRepository.CreateStoryAsync(story);
        }

        public async Task DeleteStoryAsync(int id)
        {
            var story = await _storyRepository.GetStoryByIdAsync(id);
            await _storyRepository.DeleteStoryAsync(story);
        }

        public async Task<List<Story>> GetListStoryAsync()
        {
            return await _storyRepository.GetListStoryAsync();
        }

        public async Task<Story> GetStoryByIdAsync(int id)
        {
            return await _storyRepository.GetStoryByIdAsync(id);
        }

        public async Task<bool> StoryExists(int id)
        {
            return await _storyRepository.StoryExists(id);
        }

        public async Task UpdateStoryAsync(Story story)
        {
            await _storyRepository.UpdateStoryAsync(story);
        }
    }
}
