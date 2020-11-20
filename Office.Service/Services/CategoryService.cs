using System;
using System.Threading.Tasks;
using Office.Core.Models;
using Office.Core.Repositories;
using Office.Core.Services;
using Office.Core.UnitOfWorks;

namespace Office.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await _unitOfWork.Categories.GetWithProductsByIdAsync(categoryId);
        }
    }
}
