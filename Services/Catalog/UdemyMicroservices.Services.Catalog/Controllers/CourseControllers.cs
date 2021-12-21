using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UdemyMicroservices.Services.Catalog.Services;
using UdemyMicroservices.Shared.ControllerBases;

namespace UdemyMicroservices.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseControllers : CustomBaseController
    {
        private readonly ICourseService _courseService;
        public CourseControllers(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _courseService.GetCourseById(id);
            return CreateActionResultInstance(response);
        }
    }
}
