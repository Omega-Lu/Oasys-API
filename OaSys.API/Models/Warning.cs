using System.ComponentModel.DataAnnotations;

namespace OaSys.API.Models
{
    public class Warning
    {
        [Key]
        public int WARNING_ID { get; set; }
        public string WARINING_NAME { get; set; }

        public string EMPLOYEE_ID { get; set; }

        public int WARNING_TYPE_ID { get; set; }
        public string REASON { get; set; }

    }
}
