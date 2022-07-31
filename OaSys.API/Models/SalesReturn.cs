using System.ComponentModel.DataAnnotations;

namespace OaSys.API.Models
{
    public class SalesReturn
    {
        [Key]
        public int Return_ID { get; set; }

        public int Sale_ID { get; set; }
    }
}
