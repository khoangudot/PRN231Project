using System;
using ObjectModel.Dtos;
using StoryFront.Services.IServices;

namespace StoryFront.Services
{
	public class ChapterService : BaseService, IChapterService
	{
        private readonly IHttpClientFactory _clientFactory;

        public ChapterService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> GetChaptersByStoryIdAsync<T>(int storyId, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.storyAPIBase + "/api/Chapter/story/" + storyId,
                AccessToken = token
            });
        }

        public async Task<T> GetChapterByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.storyAPIBase + "/api/Chapter/" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetChapterByIndexAsync<T>(int index, int storyId, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.storyAPIBase + $"/api/Chapter/story/{storyId}/index/{index}",
                AccessToken = token
            });
        }

        public async Task<T> CreateChapterAsync<T>(ChapterDTO chapterDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = chapterDto,
                Url = SD.storyAPIBase + "/api/Chapter",
                AccessToken = token
            });
        }

        public async Task<T> DeleteChapterAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.storyAPIBase + "/api/Chapter/" + id,
                AccessToken = token
            });
        }

    }
}

