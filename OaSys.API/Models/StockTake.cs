using System.ComponentModel.DataAnnotations;

namespace OaSys.API.Models
{
    public class StockTake
    {
        [Key]
        public int STOCKTAKE_ID { get; set; }
        public int EMPLOYEE_ID { get; set; }
        public DateTime DATE { get; set; } 
    }
}
