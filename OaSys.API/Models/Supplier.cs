using System.ComponentModel.DataAnnotations;

namespace OaSys.API.Models
{
    public class Supplier
    {

        [Key]
        public int SUPPLIER_ID { get; set; }

        public string NAME { get; set; }

        public long VAT_NUMBER { get; set; }

        public long CONTACT_NUMBER { get; set; }

        public long ALT_NUMBER { get; set; }

        public string EMAIL { get; set; }

    }
}
