﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexConfig.ViewModels
{
    public class PassViewModel : BaseSaveableViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
