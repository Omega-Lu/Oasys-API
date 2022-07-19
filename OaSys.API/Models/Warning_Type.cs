using System.ComponentModel.DataAnnotations;

namespace OaSys.API.Models
{
    public class Warning_Type
    {
        [Key]
        public int WARNING_TYPE_ID { get; set; }
        public string DESCRIPTION { get; set; }

    }
}
