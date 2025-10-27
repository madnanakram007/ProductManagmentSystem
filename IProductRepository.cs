using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagementSystem.DAL.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product entity);
        void Update(Product entity); // Update and Delete are often not async
        void Delete(Product entity);
        Task<bool> SaveChangesAsync(); // A way to commit the transaction
    }
}