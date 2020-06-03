using NexConfig.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexConfig.Interfaces
{
    public interface IResourceViewModelService
    {
        Task<IList<ResourceViewModel>> GetResources();
        Task<bool> SaveOrUpdateResource(
            IList<ResourceViewModel> resources);
    }
}
