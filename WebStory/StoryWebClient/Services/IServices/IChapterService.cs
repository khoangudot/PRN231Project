using BussinessObjects.Dtos;

namespace StoryWebClient.Services.IServices
{
    public interface IChapterService
    {
        Task<T> GetChaptersByStoryIdAsync<T>(int storyId, string token);
        Task<T> GetChapterByIdAsync<T>(int id, string token);
        Task<T> GetChapterByIndexAsync<T>(int index, int storyId, string token);
        Task<T> CreateChapterAsync<T>(ChapterDTO chapterDto, string token);
        Task<T> DeleteChapterAsync<T>(int id, string token);
    }
}
