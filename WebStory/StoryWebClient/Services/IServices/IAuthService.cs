namespace StoryWebClient.Services.IServices
{
    public interface IAuthService
    {
        Task<T> Login<T>(string email, string password);
    }
}
