using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerSeekho.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [Column("student_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [Column("student_name")]
        public string? StudentName { get; set; }

        [Column("student_address")]
        public string? StudentAddress { get; set; }

        [Column("student_gender")]
        public string? StudentGender { get; set; }

        [Column("photo_url")]
        public string? PhotoUrl { get; set; }

        [Column("student_dob")]
        public DateTime? StudentDob { get; set; }

        [Column("student_qualification")]
        public string? StudentQualification { get; set; }

        [Column("student_mobile")]
        public string? StudentMobile { get; set; }

        [ForeignKey("Course")]
        [Column("course_id")]
        public int? CourseId { get; set; }
        public Course? Course { get; set; }

        [ForeignKey("Batch")]
        [Column("batch_id")]
        public int? BatchId { get; set; }
        public Batch? Batch { get; set; }
    }
}
