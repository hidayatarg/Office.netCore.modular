using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Office.Core.Models;
using Office.Core.Repositories;

namespace Office.Data.Repositories
{
    public class CategoryRepository: Repository<Category>, ICategoryRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext;}

        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await _appDbContext.Categories
                .Include(x => x.Products)
                .FirstOrDefaultAsync(x => x.Id == categoryId);
        }
    }
}