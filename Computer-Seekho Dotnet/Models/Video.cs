using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerSeekho.Models
{
    [Table("VideoMaster")]
    public class Video
    {
        [Key]
        [Column("video_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VideoId { get; set; }

        [Column("video_path", TypeName = "nvarchar(255)")]
        public string? VideoPath { get; set; }

        [Column("video_url", TypeName = "nvarchar(255)")]
        public string? VideoUrl { get; set; }

        [ForeignKey("Album")]
        [Column("album_id")]
        public int? AlbumId { get; set; }
        public Album? Album { get; set; }

        [InverseProperty("Video")]
        public ICollection<Course?> Courses { get; set; }

        [Column("is_album_cover")]
        public bool? IsAlbumCover { get; set; }

        [Column("video_is_active")]
        public bool? VideoIsActive { get; set; }
    }
}