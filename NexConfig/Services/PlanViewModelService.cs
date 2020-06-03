using ApplicationCore.Criteria;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using NexConfig.Interfaces;
using NexConfig.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexConfig.Services
{
    public class PlanViewModelService : IPlanViewModelService
    {
        INexudusService _nexudusService { get; set; }
        IAsyncRepository<Plan> _planRepository { get; set; }

        public PlanViewModelService(INexudusService nexudusService,
            IAsyncRepository<Plan> planRepository)
        {
            _nexudusService = nexudusService;
            _planRepository = planRepository;
        }

        public async Task<IList<PlanViewModel>> GetPlans()
        {
            var plans
                = (from nexudusPlan in await _nexudusService.GetItems<Plan>()
                   join savedPlan in await _planRepository.GetAllAsync()
                   on nexudusPlan.Id equals savedPlan.Id into _savedPlanLeftJoin
                   from _savedPlan in _savedPlanLeftJoin.DefaultIfEmpty()
                   select new PlanViewModel
                   {
                       Id = nexudusPlan.Id,
                       Name = nexudusPlan.Name,
                       Price = nexudusPlan.Price,
                       IsCurrentlySaved = _savedPlan != null,
                       IsToBeSaved = false,
                       DateSaved = _savedPlan != null ? _savedPlan.DateSaved : null
                   }).ToList();

            return plans;
        }

        public async Task<bool> SaveOrUpdatePlan(IList<PlanViewModel> plans)
        {
            if (plans == null) return true;

            var nexudusPlans = await _nexudusService.GetItems<Plan>();

            foreach (var plan in plans)
            {
                if (plan.IsToBeSaved == true)
                {
                    var nexudusPlan = nexudusPlans.FirstOrDefault(p => p.Id == plan.Id);

                    if (nexudusPlan == null)
                    {
                        /// TODO: Log the error

                        continue;
                    }

                    if (plan.DateSaved.HasValue == false)
                    {
                        // IT is a new plan, add it to persistent storage
                        await _planRepository.AddAsync(nexudusPlan);
                    }
                    else
                    {
                        // We're updating an existing plan
                        var itemToSave
                            = (await _planRepository.GetAsync(
                                new FindPlanByIdCriteria(nexudusPlan.Id)))
                                .FirstOrDefault();

                        itemToSave.AdvanceInvoiceCycles = nexudusPlan.AdvanceInvoiceCycles;
                        itemToSave.Archived = nexudusPlan.Archived;
                        itemToSave.AutoCancelAfter = nexudusPlan.AutoCancelAfter;
                        itemToSave.AutoRaiseInvoices = nexudusPlan.AutoRaiseInvoices;
                        itemToSave.BookingMinuteMonthLimit = nexudusPlan.BookingMinuteMonthLimit;
                        itemToSave.BookingMinuteWeekLimit = nexudusPlan.BookingMinuteWeekLimit;
                        itemToSave.BusinessId = nexudusPlan.BusinessId;
                        itemToSave.CancellationLimitDays = nexudusPlan.CancellationLimitDays;
                        itemToSave.CancellationPeriod = nexudusPlan.CancellationPeriod;
                        itemToSave.CancelMemeberAccountAfter = nexudusPlan.CancelMemeberAccountAfter;
                        itemToSave.ChargeAndExtend = nexudusPlan.ChargeAndExtend;
                        itemToSave.CheckinPricePlanLimit = nexudusPlan.CheckinPricePlanLimit;
                        itemToSave.CheckinWeekLimit = nexudusPlan.CheckinWeekLimit;
                        itemToSave.CurrencyId = nexudusPlan.CurrencyId;
                        itemToSave.DefaultContractTerm = nexudusPlan.DefaultContractTerm;
                        itemToSave.DefaultInvoicingDay = nexudusPlan.DefaultInvoicingDay;
                        itemToSave.Description = nexudusPlan.Description;
                        itemToSave.DiscountCharges = nexudusPlan.DiscountCharges;
                        itemToSave.DiscountExtraServices = nexudusPlan.DiscountExtraServices;
                        itemToSave.DiscountTimePasses = nexudusPlan.DiscountTimePasses;
                        itemToSave.DisplayOrder = nexudusPlan.DisplayOrder;
                        itemToSave.FinancialAccountId = nexudusPlan.FinancialAccountId;
                        itemToSave.GroupName = nexudusPlan.GroupName;
                        itemToSave.HoursPricePlanLimit = nexudusPlan.HoursPricePlanLimit;
                        itemToSave.HoursWeekLimit = nexudusPlan.HoursWeekLimit;
                        itemToSave.Id = nexudusPlan.Id;
                        itemToSave.InvoiceEvery = nexudusPlan.InvoiceEvery;
                        itemToSave.InvoiceEveryWeeks = nexudusPlan.InvoiceEveryWeeks;
                        itemToSave.Name = nexudusPlan.Name;
                        itemToSave.Price = nexudusPlan.Price;
                        itemToSave.ProrateCancellations = nexudusPlan.ProrateCancellations;
                        itemToSave.ProrateDayOfMonth = nexudusPlan.ProrateDayOfMonth;
                        itemToSave.ProrateDaysBefore = nexudusPlan.ProrateDaysBefore;
                        itemToSave.RaiseInvoiceEvery = nexudusPlan.RaiseInvoiceEvery;
                        itemToSave.RaiseInvoiceEveryWeeks = nexudusPlan.RaiseInvoiceEveryWeeks;
                        itemToSave.SignUpFee = nexudusPlan.SignUpFee;
                        itemToSave.Starred = nexudusPlan.Starred;
                        itemToSave.SubscribersLimit = nexudusPlan.SubscribersLimit;
                        itemToSave.TaxRateId = nexudusPlan.TaxRateId;
                        itemToSave.TermsAndConditions = nexudusPlan.TermsAndConditions;
                        itemToSave.UseTimePasses = nexudusPlan.UseTimePasses;
                        itemToSave.Visible = nexudusPlan.Visible;

                        await _planRepository.UpdateAsync(itemToSave);

                        /// TODO: Log the error
                    }
                }
            }

            return true;
        }
    }
}
