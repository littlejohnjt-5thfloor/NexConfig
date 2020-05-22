using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class PassRepository : EfRepository<Pass>, IPassRepository
    {
        public PassRepository(ConfigurationContext dbContext) : base(dbContext) { }
    }
}
