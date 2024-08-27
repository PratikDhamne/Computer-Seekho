using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerSeekho.Models
{
    [Table("ClosureReasonMaster")]
    public class ClosureReason
    {
        [Key]
        [Column("closure_reason_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClosureReasonId { get; set; }

        [Column("closure_reason_desc", TypeName = "nvarchar(255)")]
        public string? ClosureReasonDesc { get; set; }
    }
}
