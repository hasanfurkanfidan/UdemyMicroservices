using AutoMapper;
using UdemyMicroservices.Services.Catalog.Dtos;
using UdemyMicroservices.Services.Catalog.Models;

namespace UdemyMicroservices.Services.Catalog.Mappings
{
    public class GeneralMappings : Profile
    {
        public GeneralMappings()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<CourseCreateDto, CourseDto>();
            CreateMap<CourseUpdateDto, CourseDto>();
        }
    }
}
