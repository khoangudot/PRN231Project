using AutoMapper;
using DataAccess.DbContexts;
using DataAccess.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using ObjectModel.Dtos;
using StoryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public CategoryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            IEnumerable<Category> categories = await _context.Categories.OrderBy(x => x.CategoryId).ToListAsync();
            return _mapper.Map<List<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> GetCategoryById(int categoryId)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == categoryId);
            return _mapper.Map<CategoryDTO>(category);
        }
    }
}
