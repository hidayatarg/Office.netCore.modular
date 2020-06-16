using System.Threading.Tasks;
using Office.Core.Models;

namespace Office.Core.Services
{
    interface IProductService: IService<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);

        // bool ControlInnerBarcode(Product product);
        // Product Control Method Except the Database   
    }
}