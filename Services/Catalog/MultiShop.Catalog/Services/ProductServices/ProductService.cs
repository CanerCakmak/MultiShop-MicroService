using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _ProductCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            MongoClient client = new MongoClient(_databaseSettings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ProductCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            Product value = _mapper.Map<Product>(createProductDto);
            await _ProductCollection.InsertOneAsync(value);
        }

        public async Task DeleteByIdProductAsync(string id)
        {
            await _ProductCollection.DeleteOneAsync(x => x.ProductID == id);
        }

        public async Task<List<ResponseProductDto>> GetAllProductsAsync()
        {
            List<Product> values =await _ProductCollection.Find(Product => true).ToListAsync();

            return _mapper.Map<List<ResponseProductDto>>(values);
        }

        public async Task<ResponseProductDto> GetByIdProductAsync(string id)
        {
            Product value = await _ProductCollection.Find<Product>(x => x.ProductID == id).FirstOrDefaultAsync();

            return _mapper.Map<ResponseProductDto>(value);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            Product value = _mapper.Map<Product>(updateProductDto);

            await _ProductCollection.FindOneAndReplaceAsync(x => x.ProductID == updateProductDto.ProductID, value);
        }
    }
}
