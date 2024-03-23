using BussinessObjects.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepositories
{
    public interface IChapterRepository
    {
        Task<IEnumerable<ChapterDTO>> GetChapterByStoryId(int storyId);
        Task<ChapterDTO> GetChapterById(int chapterId);
        Task<ChapterDTO> GetChapterByIndex(int index, int storyId);
        Task<ChapterDTO> CreateChapter(ChapterDTO chapterDto);
        Task<bool> DeleteChapter(int chapterId);
    }
}
