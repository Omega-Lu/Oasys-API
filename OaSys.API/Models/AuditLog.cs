using System.ComponentModel.DataAnnotations;

namespace OaSys.API.Models
{
    public class AuditLog
    {
        [Key]
        public int Audit_Log_ID { get; set; }
        public int USER_ID { get; set; }
        public int FUNCTION_USED { get; set; }
        public DateTime DATE { get; set;}


    }
}
