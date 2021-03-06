﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOModel
{
   public class Delivery
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("deliveryId")]
        public virtual List<DeliveryResource> deliveryResources { get; set; }
    }
}
