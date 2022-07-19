using System.ComponentModel.DataAnnotations;

namespace OaSys.API.Models
{
    public class Rate
    {
       // public int RATE_ID { get; set; }
      //  public string RATE_NAME { get; set; }
       // public float RATE_AMOUNT { get; set; }
       // [Key]
       [Key]
        public int RATE_ID { get; set; }
        public string RATE_NAME { get; set; }
        public float RATE_AMOUNT { get; set; }

    }
}
