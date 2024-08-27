using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerSeekho.Models
{
    [Table("Batch")]
    public class Batch
    {
        [Key]
        [Column("batch_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BatchId { get; set; }

        [Column("batch_name")]
        public string? BatchName { get; set; }

        [Column("batch_start_date")]
        public DateTime? BatchStartDate { get; set; }

        [Column("batch_end_date")]
        public DateTime? BatchEndDate { get; set; }

        [ForeignKey("Course")]
        [Column("course_id")]
        public int? CourseId { get; set; }
        public Course? Course { get; set; }

        [Column("final_presentation_date")]
        public DateTime? FinalPresentationDate { get; set; }

        [Column("batch_fees")]
        public float? BatchFees { get; set; }

        [Column("course_fees_from")]
        public DateTime? CourseFeesFrom { get; set; }

        [Column("course_fees_to")]
        public DateTime? CourseFeesTo { get; set; }

        [Column("batch_is_active")]
        public bool? BatchIsActive { get; set; }
    }
}
