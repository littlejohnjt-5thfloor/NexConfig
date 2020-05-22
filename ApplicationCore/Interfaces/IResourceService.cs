using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IResourceService
    {
        Task<IReadOnlyList<Resource>> GetAllResources();
        Task<IReadOnlyList<Resource>> GetActiveResources();
    }
}
