using ObjectModel.Dtos;
using StoryFront.Services.IServices;

namespace StoryFront.Services
{
    public class CommentService : BaseService, ICommentService
    {
        private readonly IHttpClientFactory _clientFactory;

        public CommentService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> AddCommentAsync<T>(AddCommentDTO comment, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = comment,
                Url = SD.storyAPIBase + "/api/Comment/AddComment",
                AccessToken = token
            });
        }

        public async Task<T> AddReplyAsync<T>(AddCommentDTO comment, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = comment,
                Url = SD.storyAPIBase + "/api/Comment/AddReply",
                AccessToken = token
            });
        }

        public async Task<T> DeleteCommentAsync<T>(int commentId, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.storyAPIBase + "/api/Comment/DeleteComment/"+commentId,
                AccessToken = token
            });
        }

        public async Task<T> GetAllAsync<T>(int storyId, string token)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.storyAPIBase + "/api/Comment/GetComments/"+storyId,
                AccessToken = token
            });
        }
    }
}
