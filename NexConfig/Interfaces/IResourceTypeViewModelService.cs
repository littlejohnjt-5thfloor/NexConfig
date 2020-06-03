using NexConfig.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexConfig.Interfaces
{
    public interface IResourceTypeViewModelService
    {
        Task<IList<ResourceTypeViewModel>> GetResourceTypes();
        Task<bool> SaveOrUpdateResourceType(
            IList<ResourceTypeViewModel> resourceTypes);
    }
}
