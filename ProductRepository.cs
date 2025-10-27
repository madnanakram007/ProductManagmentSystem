using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagementSystem.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product entity)
        {
            await _context.Products.AddAsync(entity);
        }

        public void Delete(Product entity)
        {
            _context.Products.Remove(entity);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            // Returns true if at least one record was changed
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Product entity)
        {
            _context.Products.Update(entity);
        }
    }
}