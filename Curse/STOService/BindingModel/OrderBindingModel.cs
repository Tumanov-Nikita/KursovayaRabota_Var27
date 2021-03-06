﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOService.BindingModels
{
   public class OrderBindingModel
    {
        public int id { get; set; }
        public int clientId { get; set; }
        public string clientName { get; set; }
        public int number { get; set; }
        public string status { get; set; }
        public DateTime DateCreate { get; set; }
        public List<ServiceBindingModel> services { get; set; }
    }
}
