using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexConfig.ViewModels
{
    public class ResourceTypeViewModel : BaseSaveableViewModel
    {
        public int BusinessId { get; set; }
        public string Name { get; set; }
    }
}
