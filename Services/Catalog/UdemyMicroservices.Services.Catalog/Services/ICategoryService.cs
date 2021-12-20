using System.Collections.Generic;
using System.Threading.Tasks;
using UdemyMicroservices.Services.Catalog.Dtos;
using UdemyMicroservices.Services.Catalog.Models;
using UdemyMicroservices.Shared.Dtos;

namespace UdemyMicroservices.Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<ICollection<CategoryDto>>> GetAllCategories();
        Task<Response<CategoryDto>> Create(Category category);
        Task<Response<CategoryDto>> GetById(string id);
    }
}
