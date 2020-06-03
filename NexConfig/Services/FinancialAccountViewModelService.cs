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
    public class FinancialAccountViewModelService : IFinancialAccountViewModelService
    {
        INexudusService _nexudusService { get; set; }
        IAsyncRepository<FinancialAccount> _financialAccountRepository { get; set; }

        public FinancialAccountViewModelService(INexudusService nexudusService,
            IAsyncRepository<FinancialAccount> financialAccountRepository)
        {
            _nexudusService = nexudusService;
            _financialAccountRepository = financialAccountRepository;
        }

        public async Task<IList<FinancialAccountViewModel>> GetFinancialAccounts()
        {
            var financialAccounts
                = (from nexudusFinancialAccount in await _nexudusService.GetItems<FinancialAccount>()
                   join savedFinancialAccount in await _financialAccountRepository.GetAllAsync()
                   on nexudusFinancialAccount.Id equals savedFinancialAccount.Id into _savedFinancialAccountLeftJoin
                   from _savedFinancialAccount in _savedFinancialAccountLeftJoin.DefaultIfEmpty()
                   select new FinancialAccountViewModel
                   {
                       Id = nexudusFinancialAccount.Id,
                       Name = nexudusFinancialAccount.Name,
                       Code = nexudusFinancialAccount.Code,
                       Description = nexudusFinancialAccount.Description,
                       IsCurrentlySaved = _savedFinancialAccount != null,
                       IsToBeSaved = false,
                       DateSaved = _savedFinancialAccount != null ? _savedFinancialAccount.DateSaved : null
                   }).ToList();

            return financialAccounts;
        }

        public async Task<bool> SaveOrUpdateFinancialAccount(IList<FinancialAccountViewModel> financialAccounts)
        {
            if (financialAccounts == null) return true;

            // Get all financial accounts
            var nexudusFinancialAccounts
                = await _nexudusService.GetItems<FinancialAccount>();

            foreach (var financialAccount in financialAccounts)
            {
                if (financialAccount.IsToBeSaved == true)
                {
                    var nexudusFinancialAccount
                        = nexudusFinancialAccounts
                        .FirstOrDefault(fa => fa.Id == financialAccount.Id);

                    if (nexudusFinancialAccount == null)
                    {
                        /// TODO: Log the error
                        continue;
                    }

                    if (financialAccount.DateSaved.HasValue == false)
                    {
                        // It is a new financial account, add it to persistent storage
                        await _financialAccountRepository.AddAsync(nexudusFinancialAccount);

                        /// TODO: Log the error
                    }
                    else
                    {
                        // We're updating a financial account
                        var itemToSave
                            = (await _financialAccountRepository
                            .GetAsync(new FindFinancialAccountByIdCriteria(nexudusFinancialAccount.Id)))
                            .FirstOrDefault();

                        itemToSave.AccountType = nexudusFinancialAccount.AccountType;
                        itemToSave.BusinessId = nexudusFinancialAccount.BusinessId;
                        itemToSave.Code = nexudusFinancialAccount.Code;
                        itemToSave.Description = nexudusFinancialAccount.Description;
                        itemToSave.Id = nexudusFinancialAccount.Id;
                        itemToSave.Name = nexudusFinancialAccount.Name;

                        await _financialAccountRepository.UpdateAsync(itemToSave);

                        /// TODO: Log the error
                    }
                }
            }

            return true;
        }
    }
}
