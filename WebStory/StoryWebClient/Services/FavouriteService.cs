using BussinessObjects.Dtos;
using StoryWebClient.Services.IServices;

namespace StoryWebClient.Services
{
    public class FavouriteService : BaseService, IFavouriteService
    {
        private readonly IHttpClientFactory _clientFactory;

        public FavouriteService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> AddFavouriteAsync<T>(string token, AddFavouriteDTO f)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = f,
                Url = SD.storyAPIBase + "/api/Favourite/AddFavourite",
                AccessToken = token
            });
        }

        public async Task<T> DeleteFavouriteAsync<T>(string token, AddFavouriteDTO f)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Data = f,
                Url = SD.storyAPIBase + $"/api/Favourite/DeleteFavourite/{f.UserId}/{f.StoryId}",
                AccessToken = token
            });
        }

        public async Task<T> GetAllAsync<T>(string token, int userId)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.storyAPIBase + "/api/Favourite/GetFavourites/" + userId,
                AccessToken = token
            });
        }
    }
}
