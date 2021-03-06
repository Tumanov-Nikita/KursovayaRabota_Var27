﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOModel
{
   public class Resource
    {
        public int id { get; set; }

        [Required]
        public string resourceName { get; set; }
        public int sumCount { get; set; }
        public int price { get; set; }

        [ForeignKey("resourceId")]
        public virtual List<DeliveryResource> deliveryResources { get; set; }
        [ForeignKey("resourceId")]
        public virtual List<ServiceResource> serviceResources { get; set; }

    }
}
