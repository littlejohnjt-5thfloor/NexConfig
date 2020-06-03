using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Criteria
{
    public class FindResourceTypeByIdCriteria : Criteria<ResourceType>
    {
        public FindResourceTypeByIdCriteria(int id) 
            : base(rt => rt.Id == id) { }
    }
}
