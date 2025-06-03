using CodePurse.API.Data;
using CodePurse.API.Models.Domain;
using CodePurse.API.Models.DTO;
using CodePurse.API.Repositories.Implementation;
using CodePurse.API.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace CodePurse.API.Controllers
{
    [Route("/api/[Controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDBContext dBContext;
        //private readonly CategoryRepository categoryRepository;

        public CategoriesController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
            // this.categoryRepository = _categoryRepository;
        }


        [HttpPost]
        public async Task<IActionResult> CreateNewCategory(CreateCategoryRequestDto requestDto)
        {
            Category category = new Category
            {
                Name = requestDto.Name,
                UrlHandle = requestDto.UrlHandle
            };

            await dBContext.Categories.AddAsync(category);
            await dBContext.SaveChangesAsync();

            var response = new CategoryDTO
            {
                Id = category.Id,
                Name = requestDto.Name,
                UrlHandle = requestDto.UrlHandle
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            // CategoryRepository categoryRepository = new CategoryRepository(dBContext);

            //var categories= await categoryRepository.GetAllCategory();

            List<Category> categorylist = dBContext.Categories.ToList();



            return Ok(categorylist);
        }
        // from body ? and from url ? and why in []
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult?> GetCategoryById([FromRoute] Guid id) {

            var category =  dBContext.Categories.FirstOrDefault(X => X.Id == id);

            if (category is null) {
                return this.NotFound("No result found.");
            }

            return Ok(category);
        }
    }
}
