using System;
using System.Threading.Tasks;
using Office.Core.Models;

namespace Office.Core.Repositories
{
    interface ICategoryRepository: IRepository<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}
