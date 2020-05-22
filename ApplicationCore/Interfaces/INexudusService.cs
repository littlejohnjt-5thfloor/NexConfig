using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface INexudusService
    {
        Task<IReadOnlyList<Plan>> GetAllPlans();
        Task<IReadOnlyList<Plan>> GetActivePlans();
        Task<IReadOnlyList<Resource>> GetAllResources();
        Task<IReadOnlyList<Resource>> GetActiveResources();
        Task<IReadOnlyList<Pass>> GetAllPasses();
        Task<IReadOnlyList<Pass>> GetActivePasses();
        Task<IReadOnlyList<Product>> GetAllProducts();
        Task<IReadOnlyList<Product>> GetActiveProducts();
        Task<IReadOnlyList<FinancialAccount>> GetAllFinancialAccounts();
    }
}
