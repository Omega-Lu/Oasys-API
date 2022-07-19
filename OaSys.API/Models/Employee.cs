using System.ComponentModel.DataAnnotations;

namespace OaSys.API.Models
{
    public class Employee
    {
        [Key]
        public int EMPLOYEE_ID { get; set; }
        public long EMPLOYEE_ID_NUMBER { get; set; }
        public int PROVINCE_ID { get; set; }
        public int EMPLOYEE_TYPE_ID { get; set; }
        public int EMPLOYEE_STATUS_ID { get; set; }
        public int WARNING_ID { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public string TITLE { get; set; }
        public long CONTACT_NUMBER { get; set; }
        public string EMAIL { get; set; }
        public string ADDRESS { get; set; }

    }
}
