using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Criteria
{
    public class FindBusinessByIdCriteria : Criteria<Business>
    {
        public FindBusinessByIdCriteria(int id) : base(b => b.Id == id) { }
    }
}
