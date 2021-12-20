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
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        private readonly IDatabaseSettings _databaseSettings;
        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
            _databaseSettings = databaseSettings;
        }

        public async Task<Response<ICollection<CategoryDto>>> GetAllCategories()
        {
            var categories = await _categoryCollection.Find(category => true).ToListAsync();
            return Response<ICollection<CategoryDto>>.Success(_mapper.Map<ICollection<CategoryDto>>(categories), 200);
        }

        public async Task<Response<CategoryDto>> Create(Category category)
        {
            await _categoryCollection.InsertOneAsync(category);
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }

        public async Task<Response<CategoryDto>> GetById(string id)
        {
            var category = await _categoryCollection.Find<Category>(p => p.Id == id).SingleOrDefaultAsync();
            return category is null
                ? Response<CategoryDto>.Fail("Category Not Found", 404)
                : Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }
    }
}
