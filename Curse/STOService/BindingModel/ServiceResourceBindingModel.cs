﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOService.BindingModel
{
   public class ServiceResourceBindingModel
    {
        public int id { get; set; }
        public int serviceId { get; set; }
        public int resourceId { get; set; }
        public int count { get; set; }
        public string resourceName { get; set; }

    }
}
