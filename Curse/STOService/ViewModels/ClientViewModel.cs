﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace STOService.ViewModels
{
    public class ClientViewModel
    {
        public int id { get; set; }
        public string clientFirstName { get; set; }
        public string clientSecondName { get; set; }
        public int number { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public bool blocked { get; set; }
        public int sanction { get; set; }
        public virtual List<OrderViewModel> Orders { get; set; }
        [DataMember]
        public List<MessageInfoViewModel> messages { get; set; }
    }
}
