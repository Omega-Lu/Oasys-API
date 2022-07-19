using System.ComponentModel.DataAnnotations;

namespace OaSys.API.Models
{
    public class User
    {
        [Key]
        public int USER_ID { get; set; }

        public int USER_ROLE_ID { get; set; }

        public int EMPLOYEE_ID { get; set; }

        public int USER_STATUS_ID { get; set; }
        [Required]
        public string USERNAME { get; set; }
        [Required]
        public string USER_PASSWORD { get; set; }
        

    }
}
