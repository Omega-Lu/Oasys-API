using System.ComponentModel.DataAnnotations;

namespace OaSys.API.Models
{
    public class Employee_Type
    {
        [Key]
        public int EMPLOYEE_TYPE_ID { get; set; }
        public int USER_ROLE_ID { get; set; }
        public string POSITION_NAME { get; set; }
    }
}
