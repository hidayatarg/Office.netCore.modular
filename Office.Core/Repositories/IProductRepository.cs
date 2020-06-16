using System;
using System.Threading.Tasks;
using Office.Core.Models;

namespace Office.Core.Repositories
{
    internal interface IProductRepository: IRepository<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
