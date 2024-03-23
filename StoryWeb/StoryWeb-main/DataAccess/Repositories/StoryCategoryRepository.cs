using DataAccess.DbContexts;
using DataAccess.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class StoryCategoryRepository : IStoryCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public StoryCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
