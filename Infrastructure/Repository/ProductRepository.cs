using EssentialsSupps_Backend.Domain.Interfaces;
using EssentialsSupps_Backend.Domain.Models;
using EssentialsSupps_Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EssentialsSupps_Backend.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
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

        // Get all products
        public async Task<Product> GetById(int id)
        {
            try
            {
                if (_context == null) throw new Exception("Context is null");

                var result = await _context.Products
                    .AsNoTracking()
                    .Include(x => x.Productcategories)
                    .Include(x => x.Productmedia)
                    .Include(x => x.Saledetails)
                    .Include(x => x.Shoppingcartitems)
                    .FirstOrDefaultAsync(x => x.IdProduct == id);

                if (result == null) throw new Exception("Product not found");

                var product = new Product
                {
                    IdProduct = result.IdProduct,
                    CodeProduct = result.CodeProduct,
                    NameProduct = result.NameProduct,
                    Description = result.Description,
                    PriceProduct = result.PriceProduct,
                    Stock = result.Stock,
                    Isactive = result.Isactive,
                    Createdat = result.Createdat,
                    Updateat = result.Updateat,
                    Productcategories = result.Productcategories,
                    Productmedia = result.Productmedia,
                    Saledetails = result.Saledetails,
                    Shoppingcartitems = result.Shoppingcartitems
                };

                return product;
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                throw new Exception($"An error occurred while retrieving the product: {ex.Message}");
            }
        }

#warning This method is not implemented

        public Task Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
