using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace STOModel
{
   public class Client
    {
        public int id { get; set; }

        [Required]
        public string clientFirstName { get; set; }
        [Required]
        public string clientSecondName { get; set; }
        public int number { get; set; }
        public string password { get; set; }
        public string mail { get; set; }
        public bool blocked { get; set; }
        public int sanction { get; set; }

        [ForeignKey("clientId")]
        public virtual List<Order> Orders { get; set; }
    }
}
