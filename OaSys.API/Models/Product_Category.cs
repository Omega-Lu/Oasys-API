using System.ComponentModel.DataAnnotations;

namespace OaSys.API.Models
{
    public class Product_Category
    {
        [Key]
        public int PRODUCT_CATEGORY_ID { get; set; }
        public string CATEGORY_NAME { get; set; }
        public string CATEGORY_DESCRIPTION { get; set; }
    }
}
