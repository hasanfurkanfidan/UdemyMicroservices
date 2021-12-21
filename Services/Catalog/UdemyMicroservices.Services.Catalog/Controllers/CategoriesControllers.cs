using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UdemyMicroservices.Services.Catalog.Services;
using UdemyMicroservices.Shared.ControllerBases;

namespace UdemyMicroservices.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesControllers : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoriesControllers(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response
        }
    }
}
