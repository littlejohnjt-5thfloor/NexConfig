using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Criteria
{
    public class FindResourceByIdCriteria : Criteria<Resource>
    {
        public FindResourceByIdCriteria(int id) 
            : base(r => r.Id == id) { }
    }
}
