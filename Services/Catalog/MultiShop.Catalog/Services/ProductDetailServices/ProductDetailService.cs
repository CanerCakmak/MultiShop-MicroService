using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.ProductDetailDetailServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _ProductDetailCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            MongoClient client = new MongoClient(_databaseSettings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ProductDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            ProductDetail value = _mapper.Map<ProductDetail>(createProductDetailDto);
            await _ProductDetailCollection.InsertOneAsync(value);
        }

        public async Task DeleteByIdProductDetailAsync(string id)
        {
            await _ProductDetailCollection.DeleteOneAsync(x => x.ProductDetailID == id);
        }

        public async Task<List<ResponseProductDetailDto>> GetAllProductDetailsAsync()
        {
            List<ProductDetail> values = await _ProductDetailCollection.Find(ProductDetail => true).ToListAsync();

            return _mapper.Map<List<ResponseProductDetailDto>>(values);
        }

        public async Task<ResponseProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            ProductDetail value = await _ProductDetailCollection.Find<ProductDetail>(x => x.ProductDetailID == id).FirstOrDefaultAsync();

            return _mapper.Map<ResponseProductDetailDto>(value);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            ProductDetail value = _mapper.Map<ProductDetail>(updateProductDetailDto);

            await _ProductDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailID == updateProductDetailDto.ProductDetailID, value);
        }
    }
}
