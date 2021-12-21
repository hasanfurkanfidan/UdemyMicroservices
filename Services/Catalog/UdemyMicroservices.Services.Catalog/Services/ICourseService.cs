using System.Collections.Generic;
using System.Threading.Tasks;
using UdemyMicroservices.Services.Catalog.Dtos;
using UdemyMicroservices.Shared.Dtos;

namespace UdemyMicroservices.Services.Catalog.Services
{
    public interface ICourseService
    {
        Task<Response<ICollection<CourseDto>>> GetAllCourses();
        Task<Response<CourseDto>> GetCourseById(string id);
        Task<Response<CourseDto>> CreateCourse(CourseCreateDto course);
    }
}
