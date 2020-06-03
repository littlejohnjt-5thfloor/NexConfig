using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NexConfig.ViewModels
{
    public class BusinessViewModel : BaseSaveableViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string WebAddress { get; set; }
        public string ContactEmail { get; set; }
    }
}
