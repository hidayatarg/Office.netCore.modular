using System.Threading.Tasks;
using Office.Core.Repositories;

namespace Office.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        Task CommitAsync();

        void Commit();
    }
}