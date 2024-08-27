using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerSeekho.Models
{
    [Table("Staff")]
    public class Staff
    {
        [Key]
        [Column("staff_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffId { get; set; }

        [Column("staff_name")]
        public string? StaffName { get; set; }

        [Column("photo_url")]
        public string? PhotoUrl { get; set; }

        [Column("staff_role")]
        public string? StaffRole { get; set; }

        [Column("staff_mobile")]
        public string? StaffMobile { get; set; }

        [Column("staff_email")]
        public string? StaffEmail { get; set; }

        [Column("staff_username")]
        public string? StaffUsername { get; set; }

        [Column("staff_password")]
        public string? StaffPassword { get; set; }

        public ICollection<Followup?> Followups { get; set; }

        public ICollection<Enquiry?> Enquiries { get; set; }
    }
}
