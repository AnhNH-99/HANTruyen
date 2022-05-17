using HANTruyen.Models.Entities;
using HANTruyen.Repositories.Stories;
using HANTruyen.ViewModels.Stories;
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

        public async Task CreateStoryAsync(StoryCreateViewModel request)
        {
            var story = new Story()
            {
                Name = request.Name,
                Title = request.Title,
                Description = request.Description,
                Author = request.Author
            };
            await _storyRepository.CreateStoryAsync(story);
        }

        public async Task DeleteStoryAsync(int id)
        {
            var story = await _storyRepository.GetStoryByIdAsync(id);
            await _storyRepository.DeleteStoryAsync(story);
        }

        public async Task<List<StoryViewModel>> GetListStoryAsync()
        {
            return await _storyRepository.GetListStoryAsync();
        }

        public async Task<StoryViewModel> GetStoryByIdAsync(int id)
        {
            var story = await _storyRepository.GetStoryByIdAsync(id);
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
            return await _storyRepository.StoryExists(id);
        }

        public async Task UpdateStoryAsync(StoryEditViewModel request)
        {
            var story = await _storyRepository.GetStoryByIdAsync(request.Id);
            story.Name = request.Name;
            story.Title = request.Title;
            story.Description = request.Description;
            story.Status = request.Status;
            story.Author = request.Author;
            await _storyRepository.UpdateStoryAsync(story);
        }
    }
}
