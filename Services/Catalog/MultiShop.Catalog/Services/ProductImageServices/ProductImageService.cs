using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _ProductImageCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            MongoClient client = new MongoClient(_databaseSettings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ProductImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            ProductImage value = _mapper.Map<ProductImage>(createProductImageDto);
            await _ProductImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteByIdProductImageAsync(string id)
        {
            await _ProductImageCollection.DeleteOneAsync(x => x.ProductImageID == id);
        }

        public async Task<List<ResponseProductImageDto>> GetAllProductImagesAsync()
        {
            List<ProductImage> values = await _ProductImageCollection.Find(ProductImage => true).ToListAsync();

            return _mapper.Map<List<ResponseProductImageDto>>(values);
        }

        public async Task<ResponseProductImageDto> GetByIdProductImageAsync(string id)
        {
            ProductImage value = await _ProductImageCollection.Find<ProductImage>(x => x.ProductImageID == id).FirstOrDefaultAsync();

            return _mapper.Map<ResponseProductImageDto>(value);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            ProductImage value = _mapper.Map<ProductImage>(updateProductImageDto);

            await _ProductImageCollection.FindOneAndReplaceAsync(x => x.ProductImageID == updateProductImageDto.ProductImageID, value);
        }
    }
}
