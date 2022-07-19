using System.ComponentModel.DataAnnotations;

namespace OaSys.API.Models
{
    public class Customer_Account
    {
        [Key]
        public int CUSTOMER_ACCOUNT_ID { get; set; }
        public int ACCOUNT_STATUS_ID { get; set; }
        public int PROVINCE_ID { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public string EMAIL { get; set; }
        public long CONTACT_NUMBER { get; set; }
        public float AMOUNT_OWING { get; set; }
        public float CREDIT_LIMIT { get; set; }
        public string REMINDER_MESSAGE { get; set; }

    }
}
