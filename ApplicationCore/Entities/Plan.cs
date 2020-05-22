using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Plan : BaseEntity
    {
        public int BusinessId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? DefaultInvoicingDay { get; set; }
        public bool? Visible { get; set; }
        public bool? UseTimePasses { get; set; }
        public string Description { get; set; }
        public decimal? SignUpFee { get; set; }
        public int CurrencyId { get; set; }
        public int? TaxRateId { get; set; }
        public int? FinancialAccountId { get; set; }
        public string TermsAndConditions { get; set; }
        public int CancellationPeriod { get; set; }
        public int DisplayOrder { get; set; }
        public string GroupName { get; set; }
        public int? SubscribersLimit { get; set; }
        public int? CancellationLimitDays { get; set; }
        public int? DefaultContractTerm { get; set; }
        public int? CancelMemeberAccountAfter { get; set; }
        public int? CheckinPricePlanLimit { get; set; }
        public int? CheckinWeekLimit { get; set; }
        public int? HoursPricePlanLimit { get; set; }
        public int? HoursWeekLimit { get; set; }
        public int? BookingMinuteWeekLimit { get; set; }
        public int? BookingMinuteMonthLimit { get; set; }
        public decimal? DiscountExtraServices { get; set; }
        public decimal? DiscountTimePasses { get; set; }
        public decimal? DiscountCharges { get; set; }
        public int InvoiceEvery { get; set; }
        public int InvoiceEveryWeeks { get; set; }
        public int? AutoCancelAfter { get; set; }
        public int? AdvanceInvoiceCycles { get; set; }
        public int? ProrateDayOfMonth { get; set; }
        public int? ProrateDaysBefore { get; set; }
        public bool? ProrateCancellations { get; set; }
        public int? ChargeAndExtend { get; set; }
        public bool? AutoRaiseInvoices { get; set; }
        public int? RaiseInvoiceEvery { get; set; }
        public int? RaiseInvoiceEveryWeeks { get; set; }
        public bool? Archived { get; set; }
        public bool? Starred { get; set; }
    }
}
