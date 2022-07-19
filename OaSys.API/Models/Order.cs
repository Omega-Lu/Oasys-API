using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OaSys.API.Models
{
    public class Order
    {
        [Key]
        public int ORDER_ID { get; set; }
        public int SUPPLIER_ID { get; set; }
        public string ORDER_STATUS { get; set; }
        public DateTime DATE_PLACED { get; set; }
        public DateTime DATE_RECEIVED { get; set; }


    }
}
