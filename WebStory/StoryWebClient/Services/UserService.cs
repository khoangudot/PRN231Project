using BussinessObjects.Dtos;
using StoryWebClient.Services.IServices;

namespace StoryWebClient.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IHttpClientFactory _clientFactory;

        public UserService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> GetAllUsersAsync<T>(string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.storyAPIBase + "/api/User",
                AccessToken = token
            });
        }

        public async Task<T> GetUserByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.storyAPIBase + "/api/User/" + id,
                AccessToken = token
            });
        }

        public async Task<T> CreateUserAsync<T>(UserDTO userDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = userDto,
                Url = SD.storyAPIBase + "/api/User",
                AccessToken = token
            });
        }

        public async Task<T> UpdateUserAsync<T>(UserDTO userDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = userDto,
                Url = SD.storyAPIBase + "/api/User",
                AccessToken = token
            });
        }

        public async Task<T> DeleteUserAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.storyAPIBase + "/api/User/" + id,
                AccessToken = token
            });
        }

        public async Task<T> UpdatePasswordAsync<T>(UserDTO userDto, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = userDto,
                Url = SD.storyAPIBase + "/api/User/ChangePassword",
                AccessToken = token
            });
        }
    }
}
