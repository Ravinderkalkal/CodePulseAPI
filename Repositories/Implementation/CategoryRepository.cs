using CodePurse.API.Data;
using CodePurse.API.Models.Domain;
using CodePurse.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CodePurse.API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext applicationDBContext;
        public CategoryRepository(ApplicationDBContext dbContext)
        {
            applicationDBContext = dbContext;
        }
        public async Task<Category> CreateCategory(Category category)
        {
            await applicationDBContext.Categories.AddAsync(category);
            await applicationDBContext.SaveChangesAsync();

            return category;
        }

        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            //use the applicationDBCo

            return await applicationDBContext.Categories.ToListAsync();
        }
    }
}
