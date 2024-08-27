using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerSeekho.Models
{
    [Table("Followup")]
    public class Followup
    {
        [Key]
        [Column("followupid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FollowupId { get; set; }

        [ForeignKey("EnquiryId")]
        [Column("enquiry_id")]
        public int? EnquiryId { get; set; }
        public Enquiry? Enquiry { get; set; }

        [ForeignKey("StaffId")]
        [Column("staff_id")]
        public int? StaffId { get; set; }
        public Staff? Staff { get; set; }

        [Column("followup_date")]
        public DateTime? FollowupDate { get; set; }

        [Column("followup_msg")]
        public string? FollowupMsg { get; set; }

        [Column("is_active")]
        public bool? IsActive { get; set; }
    }
}
