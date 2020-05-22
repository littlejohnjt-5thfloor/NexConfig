using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class FinancialAccountService : IFinancialAccountService
    {
        private INexudusService _nexudusService { get; set; }

        public FinancialAccountService(INexudusService nexudusService)
        {
            _nexudusService = nexudusService;
        }

        public async Task<IReadOnlyList<FinancialAccount>> GetAllFinancialAccounts()
        {
            return await _nexudusService.GetAllFinancialAccounts();
        }
    }
}
