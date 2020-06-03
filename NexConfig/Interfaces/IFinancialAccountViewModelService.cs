using NexConfig.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexConfig.Interfaces
{
    public interface IFinancialAccountViewModelService
    {
        Task<IList<FinancialAccountViewModel>> GetFinancialAccounts();

        Task<bool> SaveOrUpdateFinancialAccount
            (IList<FinancialAccountViewModel> financialAccounts);
    }
}
