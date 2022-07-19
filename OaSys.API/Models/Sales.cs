using System.ComponentModel.DataAnnotations;

namespace OaSys.API.Models
{
    public class Sales
    {
        [Key]
        public int SALE_ID { get; set; }
        public int USER_ID  { get; set; }
        public int CUSTOMER_ACCOUNT_ID { get; set; }
        public DateTime DATE { get; set; }
        public decimal TOTAL { get; set; }

    }
}
