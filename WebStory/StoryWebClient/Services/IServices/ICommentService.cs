using BussinessObjects.Dtos;

namespace StoryWebClient.Services.IServices
{
    public interface ICommentService
    {
        Task<T> GetAllAsync<T>(int storyId, string token);
        Task<T> AddCommentAsync<T>(AddCommentDTO comment, string token);
        Task<T> AddReplyAsync<T>(AddCommentDTO comment, string token);
        Task<T> DeleteCommentAsync<T>(int commentId, string token);
    }
}
