using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private INexudusService _nexudusService { get; set; }

        public ProductService(INexudusService nexudusService)
        {
            _nexudusService = nexudusService;
        }

        public async Task<IReadOnlyList<Product>> GetAllProducts()
        {
            return await _nexudusService.GetAllProducts();
        }

        public async Task<IReadOnlyList<Product>> GetActiveProducts()
        {
            return await _nexudusService.GetActiveProducts();
        }
    }
}
