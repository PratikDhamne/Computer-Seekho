using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerSeekho.Models
{
    [Table("PaymentTypeMaster")]
    public class PaymentType
    {
        [Key]
        [Column("payment_type_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentTypeId { get; set; }

        [Column("payment_type_desc")]
        public string? PaymentTypeDesc { get; set; }
    }
}
