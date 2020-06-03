using NexConfig.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexConfig.Interfaces
{
    public interface IPassViewModelService
    {
        Task<IList<PassViewModel>> GetPasses();

        Task<bool> SaveOrUpdatePass(
            IList<PassViewModel> passes);
    }
}
