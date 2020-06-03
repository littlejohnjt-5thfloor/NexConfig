using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Criteria
{
    public class FindProductByIdCriteria : Criteria<Product>
    {
        public FindProductByIdCriteria(int id) 
            : base(p => p.Id == id) { }
    }
}
