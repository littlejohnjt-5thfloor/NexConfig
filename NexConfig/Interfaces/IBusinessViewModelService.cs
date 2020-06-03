using NexConfig.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexConfig.Interfaces
{
    public interface IBusinessViewModelService
    {
        Task<IList<BusinessViewModel>> GetBusinesses();

        Task<bool> SaveOrUpdateBusiness(IList<BusinessViewModel> businesses);
    }
}
