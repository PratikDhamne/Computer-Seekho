using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerSeekho.Models
{
    [Table("Course")]
    public class Course
    {
        [Key]
        [Column("course_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        [Column("course_name")]
        public string? CourseName { get; set; }

        [Column("course_description")]
        public string? CourseDescription { get; set; }

        [Column("course_duration")]
        public int? CourseDuration { get; set; }

        [Column("course_syllabus")]
        public string? CourseSyllabus { get; set; }

        [Column("age_grp_type")]
        public string? AgeGrpType { get; set; }

        [Column("course_is_active")]
        public bool? CourseIsActive { get; set; }

        [Column("cover_photo")]
        public string? CoverPhoto { get; set; }

        [ForeignKey("VideoId")]
        [Column("video_id")]
        public int? VideoId { get; set; }
        public Video? Video { get; set; }

        [InverseProperty("Course")]
        public ICollection<Enquiry?> Enquiries { get; set; } = new List<Enquiry>();
    }
}
