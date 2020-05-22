using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ITokenRepository : IAsyncRepository<AccessToken>
    {
        Task<AccessToken> GetByClientIdAsync(string clientId);
    }
}
