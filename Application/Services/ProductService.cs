using EssentialsSupps_Backend.Application.Interfaces;
using EssentialsSupps_Backend.Domain.Interfaces;
using EssentialsSupps_Backend.Domain.Models;

namespace EssentialsSupps_Backend.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        #warning This method is not implemented

        public Task Create(Product product)
        {
            throw new NotImplementedException();
        }

        #warning This method is not implemented


        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        #warning This method is not implemented


        public Task<IEnumerable<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        // Get product by id
        public async Task<Product> GetById(int id)
        {
            var result = await _productRepository.GetById(id);
            return result;
        }

        #warning This method is not implemented


        public Task Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
