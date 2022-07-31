using System.ComponentModel.DataAnnotations;

namespace OaSys.API.Models
{
    public class SaleProduct
    {
        [Key]
        public int SALE_ID { get; set; }

        public int PRODUCT_ID { get; set; }

        public float QUANTITY { get; set; }
    }
}
