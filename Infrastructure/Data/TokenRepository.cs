using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class TokenRepository : EfRepository<AccessToken>, ITokenRepository
    {
        public TokenRepository(ConfigurationContext dbContext)
            : base(dbContext) { }

        public async Task<AccessToken> GetByClientIdAsync(string clientId)
        {
            return await _dbContext.Set<AccessToken>()
                .FirstOrDefaultAsync(
                t => t.ClientId == clientId);
        }
    }
}
