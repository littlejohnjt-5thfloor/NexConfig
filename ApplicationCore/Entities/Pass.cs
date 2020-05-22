using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Pass : BaseEntity
    {
        public int BusinessId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? MinutesIncluded { get; set; }
        public bool CountsTowardsPlanLimits { get; set; }
        public int CurrencyId { get; set; }
        public int TaxRateId { get; set; }
        public int FinancialAccountId { get; set; }
        public bool Archived { get; set; }
    }
}
