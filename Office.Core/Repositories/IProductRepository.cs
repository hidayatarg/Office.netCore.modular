using System;
using System.Threading.Tasks;
using Office.Core.Models;

namespace Office.Core.Repositories
{
    internal interface IProductRepository
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
