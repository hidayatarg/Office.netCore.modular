using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Office.Core.Models;
using Office.Core.Repositories;

namespace Office.Data.Repositories
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext;}
        
        public ProductRepository(DbContext context) : base(context)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            var product = _appDbContext.Products
                .Include(x => x.Category)
                .SingleOrDefaultAsync(x => x.Id == productId);
            return await product;
        }
    }
}