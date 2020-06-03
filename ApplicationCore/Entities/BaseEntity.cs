using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    [Serializable]
    public class BaseEntity
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public DateTime? DateSaved { get; set; }
    }
}
