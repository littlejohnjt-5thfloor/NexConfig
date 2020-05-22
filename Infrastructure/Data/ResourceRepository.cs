using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ResourceRepository : EfRepository<Resource>, IResourceRepository
    {
        public ResourceRepository(ConfigurationContext dbContext) : base(dbContext) { }
    }
}
