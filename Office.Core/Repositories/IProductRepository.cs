using System;
using System.Threading.Tasks;
using Office.Core.Models;

namespace Office.Core.Repositories
{
    public interface IProductRepository: IRepository<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
