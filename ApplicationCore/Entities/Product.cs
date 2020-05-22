using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Product : BaseEntity
    {
        public int BusinessId { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public string Tags { get; set; }
        public int DisplayOrder { get; set; }
        public decimal Price { get; set; }
        public bool? Visible { get; set; }
        public int CurrencyId { get; set; }
        public int? TaxRateId { get; set; }
        public int? FinancialAccountId { get; set; }
        public int? AvailableAs { get; set; }
        public bool? OnlyForContacts { get; set; }
        public bool? OnlyForMembers { get; set; }
        public bool? Archived { get; set; }
        public bool? Starred { get; set; }
        public bool? TrackStock { get; set; }
        public bool? AllowNegativeStock { get; set; }
        public int? StockAlertLevel { get; set; }
    }
}
