using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerSeekho.Models
{
    [Table("receipt")]
    public class Receipt
    {
        [Key]
        [Column("receipt_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReceiptId { get; set; }

        [Column("receipt_date")]
        public DateTime? ReceiptDate { get; set; }

        [Column("receipt_amount")]
        public double? ReceiptAmount { get; set; }

        [ForeignKey("Payment")]
        [Column("payment_id")]
        public int? PaymentId { get; set; }

        public Payment? Payment { get; set; }
    }

}
