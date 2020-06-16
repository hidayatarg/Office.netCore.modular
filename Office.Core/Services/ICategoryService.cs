using System.Threading.Tasks;
using Office.Core.Models;

namespace Office.Core.Services
{
    public interface ICategoryService: IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);
        // Category Independent Methods 
    }
}