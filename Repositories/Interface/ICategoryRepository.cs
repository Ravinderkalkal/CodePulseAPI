using System.Collections.Generic;
using CodePurse.API.Models.Domain;

namespace CodePurse.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategory(Category category);
        Task<IEnumerable<Category>> GetAllCategory();
    }
}
