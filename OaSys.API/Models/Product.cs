using System.ComponentModel.DataAnnotations;

namespace OaSys.API.Models
{
    public class Product
    {
        [Key]
        public int PRODUCT_ID { get; set; }
        public int PRODUCT_CATEGORY_ID { get; set; }
        public int PRODUCT_TYPE_ID { get; set; }
        public string PRODUCT_NAME { get; set; }
        public string PRODUCT_DESCRIPTION { get; set; }
        public int QUANTITY_ON_HAND { get; set; }
        public float COST_PRICE { get; set; }
        public float SELLING_PRICE { get; set; }
        public int REORDER_LIMIT { get; set; }
    }
}
