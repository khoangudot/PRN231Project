﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectModel.Dtos;

namespace DataAccess.Repositories.IRepositories
{
    public interface IStoryRepository
    {
        Task<IEnumerable<StoryDTO>> GetStories();
        Task<IEnumerable<StoryDTO>> GetTop4Trending();
        Task<IEnumerable<StoryDTO>> GetTop10Popular();
        Task<IEnumerable<StoryDTO>> GetTopView(DateTime filter);
        Task<IEnumerable<StoryDTO>> GetStoriesByName(string name);
        Task<IEnumerable<StoryDTO>> GetStoriesByCategory(int categoryId);
        Task<IEnumerable<StoryDTO>> GetStoriesByCategoryId(int categoryId);
        Task<StoryDTO> GetStoryById(int storyId);
        Task<StoryDTO> CreateStory(StoryDTO storyDto);
        Task<StoryDTO> UpdateStory(StoryDTO storyDto);
        Task<bool> DeleteStory(int storyId);
    }
}
