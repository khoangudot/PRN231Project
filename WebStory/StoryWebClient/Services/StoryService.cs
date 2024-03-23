using BussinessObjects.Dtos;
using StoryWebClient.Services.IServices;

namespace StoryWebClient.Services
{
    public class StoryService : BaseService, IStoryService
    {
        private readonly IHttpClientFactory _clientFactory;

        public StoryService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> GetAllStorysAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.storyAPIBase + "/api/Story",
                AccessToken = token
            });
        }

        public async Task<T> GetStoryByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.storyAPIBase + "/api/Story/" + id,
                AccessToken = token
            });
        }

        public async Task<T> CreateStoryAsync<T>(StoryDTO storyDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = storyDto,
                Url = SD.storyAPIBase + "/api/Story",
                AccessToken = token
            });
        }

        public async Task<T> UpdateStoryAsync<T>(StoryDTO storyDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = storyDto,
                Url = SD.storyAPIBase + "/api/Story",
                AccessToken = token
            });
        }

        public async Task<T> DeleteStoryAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.storyAPIBase + "/api/Story/" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetTop4TrendingAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.storyAPIBase + "/api/Story/GetTop4Trending",
                AccessToken = token
            });
        }

        public async Task<T> GetTop10PopularAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.storyAPIBase + "/api/Story/GetTop10Popular",
                AccessToken = token
            });
        }

        public async Task<T> GetTopViewAsync<T>(DateTime filterDate, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.storyAPIBase + "/api/Story/GetTopView/" + filterDate.ToString("yyyy-MM-dd HH:mm:ss"),
                AccessToken = token
            });
        }

        public async Task<T> GetStoryByCategoryId<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.storyAPIBase + "/api/Story/GetStoryByCategoryId/" + id,
                AccessToken = token
            });
        }

        public async Task<T> SearchStoriesByNameAsync<T>(string token, string search)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.storyAPIBase + "/api/Story/SearchStoriesByName/" + search,
                AccessToken = token
            });
        }
    }
}
