using StoryWebClient.Services.IServices;

namespace StoryWebClient.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;

        public AuthService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> Login<T>(string email, string password)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.storyAPIBase + "/api/Authentication/authenticate/" + email + "/" + password
            });
        }
    }
}
