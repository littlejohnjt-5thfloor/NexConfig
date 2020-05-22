using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IProductService
    {
        Task<IReadOnlyList<Product>> GetAllProducts();
        Task<IReadOnlyList<Product>> GetActiveProducts();
    }
}
