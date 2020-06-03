using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Criteria
{
    public class FindPassByIdCriteria : Criteria<Pass>
    {
        public FindPassByIdCriteria(int id) 
            : base(p => p.Id == id) { }
    }
}
