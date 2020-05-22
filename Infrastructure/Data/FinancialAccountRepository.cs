using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class FinancialAccountRepository : EfRepository<FinancialAccount>, IFinancialAccountRepository
    {
        public FinancialAccountRepository(ConfigurationContext dbContext) : base(dbContext) { }
    }
}
