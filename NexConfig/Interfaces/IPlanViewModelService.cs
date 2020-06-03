using NexConfig.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexConfig.Interfaces
{
    public interface IPlanViewModelService
    {
        Task<IList<PlanViewModel>> GetPlans();

        Task<bool> SaveOrUpdatePlan(IList<PlanViewModel> plans);
    }
}
