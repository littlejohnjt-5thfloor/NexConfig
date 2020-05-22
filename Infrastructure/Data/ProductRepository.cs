using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProductRepository : EfRepository<Product>, IProductRepository
    {
        public ProductRepository(ConfigurationContext dbContext) : base(dbContext) { }
    }
}
