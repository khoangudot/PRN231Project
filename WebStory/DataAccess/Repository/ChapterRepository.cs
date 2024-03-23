using AutoMapper;
using BussinessObjects.Dtos;
using DataAccess.DbContexts;
using DataAccess.Entities;
using DataAccess.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ChapterRepository : IChapterRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public ChapterRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ChapterDTO>> GetChapterByStoryId(int storyId)
        {
            IEnumerable<Chapter> chapters = await _context.Chapters
                .Include(x => x.Images)
                .OrderBy(x => x.Index)
                .Where(x => x.StoryId == storyId)
                .ToListAsync();
            return _mapper.Map<List<ChapterDTO>>(chapters);
        }

        public async Task<ChapterDTO> GetChapterById(int chapterId)
        {
            Chapter chapter = await _context.Chapters
                .Include(x => x.Images)
                .FirstOrDefaultAsync(x => x.ChapterId == chapterId);
            return _mapper.Map<ChapterDTO>(chapter);
        }

        public async Task<ChapterDTO> GetChapterByIndex(int index, int storyId)
        {
            Chapter chapter = await _context.Chapters.Include(x => x.Images).FirstOrDefaultAsync(x => x.Index == index && x.StoryId == storyId);
            var story = await _context.Stories.FirstOrDefaultAsync(x => x.StoryId == storyId);
            story.View = story.View + 1;
            chapter.View = chapter.View + 1;
            _context.Stories.Update(story);
            _context.Chapters.Update(chapter);
            await _context.SaveChangesAsync();
            return _mapper.Map<ChapterDTO>(chapter);
        }

        public async Task<ChapterDTO> CreateChapter(ChapterDTO chapterDto)
        {
            Chapter chapter = _mapper.Map<ChapterDTO, Chapter>(chapterDto);
            chapter.CreateAt = DateTime.Now;
            _context.Chapters.Add(chapter);
            await _context.SaveChangesAsync();
            return _mapper.Map<Chapter, ChapterDTO>(chapter);
        }

        public async Task<bool> DeleteChapter(int chapterId)
        {
            Chapter chapter = await _context.Chapters.Include(x => x.Images).FirstOrDefaultAsync(x => x.ChapterId == chapterId);
            if (chapter == null)
            {
                return false;
            }
            _context.Chapters.Remove(chapter);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
