using EssentialsSupps_Backend.Domain.Models;

namespace EssentialsSupps_Backend.Application.Interfaces
{
    public interface IProductService 
    {
        Task<Product> GetById(int id);
        Task<IEnumerable<Product>> GetAll();
        Task Create(Product product);
        Task Update(Product product);
        Task Delete(int id);
    }
}
