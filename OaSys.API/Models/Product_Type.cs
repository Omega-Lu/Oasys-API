using System.ComponentModel.DataAnnotations;

namespace OaSys.API.Models
{
    public class Product_Type
    {
        [Key]
        public int PRODUCT_TYPE_ID { get; set; }
        public int PRODUCT_CATEGORY_ID { get; set; }
        public string TYPE_NAME { get; set; }
    }
}
