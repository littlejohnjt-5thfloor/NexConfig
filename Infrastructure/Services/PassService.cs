using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PassService : IPassService
    {
        private INexudusService _nexudusService { get; set; }

        public PassService(INexudusService nexudusService)
        {
            _nexudusService = nexudusService;
        }

        public async Task<IReadOnlyList<Pass>> GetAllPasses()
        {
            return await _nexudusService.GetAllPasses();
        }

        public async Task<IReadOnlyList<Pass>> GetActivePasses()
        {
            return await _nexudusService.GetActivePasses();
        }
    }
}
