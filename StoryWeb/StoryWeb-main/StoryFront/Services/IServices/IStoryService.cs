using System;
using ObjectModel.Dtos;

namespace StoryFront.Services.IServices
{
	public interface IStoryService
    {
        Task<T> GetAllStorysAsync<T>(string token);
        Task<T> SearchStoriesByNameAsync<T>(string token, string search);
        Task<T> GetTop4TrendingAsync<T>(string token);
        Task<T> GetTop10PopularAsync<T>(string token);
        Task<T> GetTopViewAsync<T>(DateTime filterDate, string token);
        Task<T> GetStoryByIdAsync<T>(int id, string token);
        Task<T> CreateStoryAsync<T>(StoryDTO storyDto, string token);
        Task<T> UpdateStoryAsync<T>(StoryDTO storyDto, string token);
        Task<T> DeleteStoryAsync<T>(int id, string token);
        Task<T> GetStoryByCategoryId<T>(int id, string token);
    }
}

