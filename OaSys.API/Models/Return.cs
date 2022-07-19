using System.ComponentModel.DataAnnotations;

namespace OaSys.API.Models


{
    public class Return
    {
        [Key]
        public int RETURN_ID { get; set; }
        public string REASON { get; set; }
        public DateTime DATE { get; set; }

    }
}
