using AutoMapper;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using UdemyMicroservices.Services.Catalog.Dtos;
using UdemyMicroservices.Services.Catalog.Models;
using UdemyMicroservices.Services.Catalog.Settings;
using UdemyMicroservices.Shared.Dtos;

namespace UdemyMicroservices.Services.Catalog.Services
{
    public class CourseService : ICourseService
    {
        private readonly IMongoCollection<Course> _courseCollection;
        private readonly IMapper _mapper;
        private readonly IDatabaseSettings _databaseSettings;

        public CourseService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _databaseSettings = databaseSettings;
            _courseCollection = database.GetCollection<Course>(databaseSettings.CourseCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<ICollection<CourseDto>>> GetAllCourses()
        {
            var courses = await _courseCollection.Find(p => true).ToListAsync();
            var mappedCourses = _mapper.Map<ICollection<CourseDto>>(courses);
            return Response<ICollection<CourseDto>>.Success(mappedCourses, 200);
        }

        public async Task<Response<CourseDto>> GetCourseById(string id)
        {
            var course = await _courseCollection.Find(p => p.Id == id).SingleOrDefaultAsync();
            var mappedCourse = _mapper.Map<CourseDto>(course);
            return mappedCourse is null
                ? Response<CourseDto>.Fail("Course Not Found", 400)
                : Response<CourseDto>.Success(mappedCourse, 200);
        }

        public async Task<Response<CourseDto>> CreateCourse(CourseCreateDto course)
        {
            var mappedCourse = _mapper.Map<Course>(course);
            await _courseCollection.InsertOneAsync(mappedCourse);
            var insertedCourse = _mapper.Map<CourseDto>(mappedCourse);
            return Response<CourseDto>.Success(insertedCourse, 200);
        }
    }
}
