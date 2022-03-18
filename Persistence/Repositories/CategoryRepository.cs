using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public ApplicationDbContext _categoryContext;

        public CategoryRepository(ApplicationDbContext categoryContext)
        {
            _categoryContext = categoryContext;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryContext.Categories.ToListAsync();
        }
        public async Task<Category> GetById(int? id)
        {
            return await _categoryContext.Categories.FindAsync(id);
        }
        public async Task<Category> Create(Category category)
        {
            _categoryContext.Add(category);
           await _categoryContext.SaveChangesAsync();
            return category;
        }
        public async Task<Category> Update(Category category)
        {
            _categoryContext.Update(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }
        public async Task<Category> Remove(Category category)
        {
            _categoryContext.Remove(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

    }
}
