using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class ResourceType :  BaseEntity
    {
        public int BusinessId { get; set; }
        public string Name { get; set; }
    }
}
