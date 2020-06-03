using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Criteria
{
    public class FindFinancialAccountByIdCriteria : Criteria<FinancialAccount>
    {
        public FindFinancialAccountByIdCriteria(int id) 
            : base(fa => fa.Id == id) { }
    }
}
