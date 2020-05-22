using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IPassService
    {
        Task<IReadOnlyList<Pass>> GetAllPasses();
        Task<IReadOnlyList<Pass>> GetActivePasses();
    }
}
