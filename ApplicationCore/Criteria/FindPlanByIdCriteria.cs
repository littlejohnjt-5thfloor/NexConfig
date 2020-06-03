using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Criteria
{
    public class FindPlanByIdCriteria : Criteria<Plan>
    {
        public FindPlanByIdCriteria(int id) 
            : base(p => p.Id == id) { }
    }
}
