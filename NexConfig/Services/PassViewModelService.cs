using ApplicationCore.Criteria;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.CodeAnalysis.CSharp;
using NexConfig.Interfaces;
using NexConfig.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace NexConfig.Services
{
    public class PassViewModelService : IPassViewModelService
    {
        INexudusService _nexudusService { get; set; }
        IAsyncRepository<Pass> _passRepository { get; set; }

        public PassViewModelService(INexudusService nexudusService,
            IAsyncRepository<Pass> passRepository)
        {
            _nexudusService = nexudusService;
            _passRepository = passRepository;
        }

        public async Task<IList<PassViewModel>> GetPasses()
        {
            var passes
                = (from nexudusPass in await _nexudusService.GetItems<Pass>()
                   join savedPass in await _passRepository.GetAllAsync()
                   on nexudusPass.Id equals savedPass.Id into _savedPassLeftJoin
                   from _savedPass in _savedPassLeftJoin.DefaultIfEmpty()
                   select new PassViewModel
                   {
                       Id = nexudusPass.Id,
                       Name = nexudusPass.Name,
                       Price = nexudusPass.Price,
                       IsCurrentlySaved = _savedPass != null,
                       IsToBeSaved = false,
                       DateSaved = _savedPass != null ? _savedPass.DateSaved : null
                   }).ToList();

            return passes;
        }

        public async Task<bool> SaveOrUpdatePass(IList<PassViewModel> passes)
        {
            if (passes == null) return true;

            // Get all nexudus passes
            var nexudusPasses
                = await _nexudusService.GetItems<Pass>();

            foreach (var pass in passes)
            {
                if (pass.IsToBeSaved == true)
                {
                    var nexudusPass
                        = nexudusPasses.FirstOrDefault(p => p.Id == pass.Id);

                    if (nexudusPass == null)
                    {
                        /// TODO: Log the error
                        continue;
                    }

                    if (pass.DateSaved.HasValue == false)
                    {
                        // It is a new pass, add it to persistent storage
                        await _passRepository.AddAsync(nexudusPass);
                    }
                    else
                    {
                        // We're updating an existing pass
                        var itemToSave
                            = (await _passRepository.GetAsync(
                               new FindPassByIdCriteria(nexudusPass.Id)))
                               .FirstOrDefault();

                        itemToSave.Archived = nexudusPass.Archived;
                        itemToSave.BusinessId = nexudusPass.BusinessId;
                        itemToSave.CountsTowardsPlanLimits = nexudusPass.CountsTowardsPlanLimits;
                        itemToSave.CurrencyId = nexudusPass.CurrencyId;
                        itemToSave.FinancialAccountId = nexudusPass.FinancialAccountId;
                        itemToSave.Id = nexudusPass.Id;
                        itemToSave.MinutesIncluded = nexudusPass.MinutesIncluded;
                        itemToSave.Name = nexudusPass.Name;
                        itemToSave.Price = nexudusPass.Price;
                        itemToSave.TaxRateId = nexudusPass.TaxRateId;

                        await _passRepository.UpdateAsync(itemToSave);

                        /// TODO: Log the error
                    }
                }
            }

            return true;
        }
    }
}
