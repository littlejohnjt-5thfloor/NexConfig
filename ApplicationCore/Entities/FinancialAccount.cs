using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class FinancialAccount : BaseEntity
    {
        public int BusinessId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int? AccountType { get; set; }
    }
}
