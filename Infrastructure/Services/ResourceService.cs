using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ResourceService : IResourceService
    {
        private INexudusService _nexudusService { get; set; }

        public ResourceService(INexudusService nexudusService)
        {
            _nexudusService = nexudusService;
        }

        public async Task<IReadOnlyList<Resource>> GetAllResources()
        {
            return await _nexudusService.GetAllResources();
        }

        public async Task<IReadOnlyList<Resource>> GetActiveResources()
        {
            return await _nexudusService.GetActiveResources();
        }
    }
}
