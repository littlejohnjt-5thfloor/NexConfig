using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class PlanRepository : EfRepository<Plan>, IPlanRepository
    {
        public PlanRepository(ConfigurationContext dbContext) : base(dbContext) { }
    }
}
