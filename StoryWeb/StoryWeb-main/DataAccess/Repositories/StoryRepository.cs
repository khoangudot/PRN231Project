using AutoMapper;
using DataAccess.DbContexts;
using DataAccess.Models;
using DataAccess.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using ObjectModel.Dtos;
using StoryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess.Repositories
{
    public class StoryRepository : IStoryRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public StoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StoryDTO>> GetStories()
        {
            IEnumerable<Story> stories = await _context.Stories
                .Include(x => x.Chapters)
                .ThenInclude(chapter => chapter.Images)
                .Include(x => x.StoryCategories)
                .ThenInclude(category => category.Category)
                .OrderByDescending(x => x.StoryId).ToListAsync();
            return _mapper.Map<List<StoryDTO>>(stories);
        }

        public async Task<IEnumerable<StoryDTO>> GetStoriesByCategoryId(int categoryId)
        {
            IEnumerable<Story> stories = await _context.Stories
                .Include(x => x.Chapters)
                .ThenInclude(chapter => chapter.Images)
                .Include(x => x.StoryCategories)
                .ThenInclude(category => category.Category)
                .Where(x => x.StoryCategories.ToList().Select(x => x.CategoryId).Contains(categoryId))
                .OrderByDescending(x => x.StoryId).ToListAsync();
            return _mapper.Map<List<StoryDTO>>(stories);
        }

        public async Task<IEnumerable<StoryDTO>> GetStoriesByCategory(int categoryId)
        {
            IEnumerable<Story> stories = await _context.StoryCategories.Include(x => x.Story)
                .ThenInclude(story => story.Chapters)
                .Where(x => x.CategoryId == categoryId).Select(x => x.Story).ToListAsync();
            return _mapper.Map<List<StoryDTO>>(stories);
        }

        public async Task<IEnumerable<StoryDTO>> GetStoriesByName(string name)
        {
            IEnumerable<Story> stories = await _context.Stories
               .Include(x => x.Chapters)
               .ThenInclude(chapter => chapter.Images)
               .Include(x => x.StoryCategories)
               .ThenInclude(category => category.Category).Where(x => x.Title.ToLower().Trim().Contains(name.ToLower().Trim()))
                .OrderByDescending(x => x.StoryId).ToListAsync();
            return _mapper.Map<List<StoryDTO>>(stories);
        }

        public async Task<StoryDTO> GetStoryById(int storyId)
        {
            Story story = await _context.Stories
                .Include(x => x.Chapters).ThenInclude(chapter => chapter.Images)
                .Include(x => x.StoryCategories).ThenInclude(category => category.Category)
                .FirstOrDefaultAsync(x => x.StoryId == storyId);
            return _mapper.Map<StoryDTO>(story);
        }

        public async Task<StoryDTO> CreateStory(StoryDTO storyDto)
        {
            Story story = _mapper.Map<StoryDTO, Story>(storyDto);
            story.CreateAt = DateTime.Now;
            story.IsActive = true;
            _context.Stories.Add(story);
            await _context.SaveChangesAsync();
            return _mapper.Map<Story, StoryDTO>(story);
        }

        public async Task<StoryDTO> UpdateStory(StoryDTO storyDto)
        {
            Story oldStory = await _context.Stories.Include(x => x.StoryCategories).FirstOrDefaultAsync(x => x.StoryId == storyDto.StoryId);
            oldStory.AuthorName = storyDto.AuthorName;
            oldStory.Content = storyDto.Content;
            oldStory.IsActive = storyDto.IsActive;
            var listCategory = new List<StoryCategory>();
            foreach (var cate in storyDto.ListOfCategory)
            {
                listCategory.Add(new StoryCategory { StoryId = storyDto.StoryId, CategoryId = cate.CategoryId });
            }
            oldStory.StoryCategories = listCategory;
            _context.Stories.Update(oldStory);
            await _context.SaveChangesAsync();
            return _mapper.Map<Story, StoryDTO>(oldStory);
        }

        public async Task<bool> DeleteStory(int storyId)
        {
            Story story = await _context.Stories.FirstOrDefaultAsync(x => x.StoryId == storyId);
            if (story == null)
            {
                return false;
            }
            story.IsActive = false;
            _context.Stories.Update(story);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<StoryDTO>> GetTop4Trending()
        {
            IEnumerable<Story> stories = await _context.Stories
                .Include(x => x.Chapters)
                .ThenInclude(chapter => chapter.Images)
                .Include(x => x.StoryCategories)
                .ThenInclude(category => category.Category)
                .OrderByDescending(x => x.View).Take(4).ToListAsync();
            return _mapper.Map<List<StoryDTO>>(stories);
        }

        public async Task<IEnumerable<StoryDTO>> GetTop10Popular()
        {
            IEnumerable<Story> stories = await _context.Stories
                .Include(x => x.Chapters)
                .ThenInclude(chapter => chapter.Images)
                .Include(x => x.StoryCategories)
                .ThenInclude(category => category.Category)
                .OrderByDescending(x => x.CreateAt).Take(10).ToListAsync();
            return _mapper.Map<List<StoryDTO>>(stories);
        }

        public async Task<IEnumerable<StoryDTO>> GetTopView(DateTime filter)
        {
            IEnumerable<Story> stories = await _context.Stories
                .Include(x => x.Chapters)
                .ThenInclude(chapter => chapter.Images)
                .Include(x => x.StoryCategories)
                .ThenInclude(category => category.Category)
                .Where(x => x.CreateAt > filter)
                .OrderByDescending(x => x.View).Take(2).ToListAsync();
            return _mapper.Map<List<StoryDTO>>(stories);
        }
    }
}
