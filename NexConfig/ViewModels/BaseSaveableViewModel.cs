using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexConfig.ViewModels
{
    public class BaseSaveableViewModel : BaseEntity
    {
        // Is the item currently saved to the data store
        public bool IsCurrentlySaved { get; set; }
        // Item is to be saved/updated in the data store
        public bool IsToBeSaved { get; set; }
    }
}
