using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PlanService : IPlanService
    {
        private INexudusService _nexudusService { get; set; }

        public PlanService(INexudusService nexudusService)
        {
            _nexudusService = nexudusService;
        }

        public async Task<IReadOnlyList<Plan>> GetAllPlans()
        {
            return await _nexudusService.GetAllPlans();
        }

        public async Task<IReadOnlyList<Plan>> GetActivePlans()
        {
            return await _nexudusService.GetActivePlans();
        }
    }
}
