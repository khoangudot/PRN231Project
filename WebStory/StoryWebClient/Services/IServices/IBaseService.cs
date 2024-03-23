using BussinessObjects.Dtos;

namespace StoryWebClient.Services.IServices
{
    public interface IBaseService
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
