using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerSeekho.Models
{
    [Table("Payment")]
    public class Payment
    {
        [Key]
        [Column("paymentId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }

        [ForeignKey("PaymentTypeId")]
        [Column("payment_type_id")]
        public int? PaymentTypeId { get; set; }
        public PaymentType? PaymentType { get; set; }

        [Column("payment_date")]
        public DateTime? PaymentDate { get; set; }

        [ForeignKey("StudentId")]
        [Column("student_id")]
        public int? StudentId { get; set; }
        public Student? Student { get; set; }

        [ForeignKey("CourseId")]
        [Column("course_id")]
        public int? CourseId { get; set; }
        public Course? Course { get; set; }

        [ForeignKey("BatchId")]
        [Column("batch_id")]
        public int? BatchId { get; set; }
        public Batch? Batch { get; set; }

        [Column("amount")]
        public double? Amount { get; set; }
    }
}
