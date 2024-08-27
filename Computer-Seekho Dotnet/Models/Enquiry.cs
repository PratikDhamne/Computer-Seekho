using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerSeekho.Models
{
    [Table("Enquiry")]
    public class Enquiry
    {
        [Key]
        [Column("enquiryId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnquiryId { get; set; }

        [Column("enquirer_name")]
        public string? EnquirerName { get; set; }

        [Column("enquirer_address")]
        public string? EnquirerAddress { get; set; }

        [Column("enquirer_mobile")]
        public string? EnquirerMobile { get; set; }

        [Column("enquirer_alternate_mobile")]
        public string? EnquirerAlternateMobile { get; set; }

        [Column("enquirer_emailid")]
        public string? EnquirerEmailId { get; set; }

        [Column("enquiry_date")]
        public DateTime? EnquiryDate { get; set; }

        [Column("enquirer_query")]
        public string? EnquirerQuery { get; set; }

        [Column("closure_reason")]
        public string? ClosureReason { get; set; }

        [Column("enquiry_processed_flag")]
        public bool? EnquiryProcessedFlag { get; set; }

        [ForeignKey("CourseId")]
        [Column("course_id")]
        public int? CourseId { get; set; }
        public Course? Course { get; set; }

        [ForeignKey("StaffId")]
        [Column("staff_id")]
        public int? StaffId { get; set; }
        public Staff? Staff { get; set; }

        [Column("student_name")]
        public string? StudentName { get; set; }

        [Column("enquiry_counter")]
        public int? EnquiryCounter { get; set; }

        [Column("followup_date")]
        public DateTime? FollowUpDate { get; set; }
    }
}
