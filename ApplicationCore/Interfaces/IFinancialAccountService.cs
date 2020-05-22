using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IFinancialAccountService
    {
        Task<IReadOnlyList<FinancialAccount>> GetAllFinancialAccounts();
    }
}
