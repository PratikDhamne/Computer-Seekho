using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerSeekho.Models
{
    [Table("ImageMaster")]
    public class Image
    {
        [Key]
        [Column("image_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId { get; set; }

        [Column("image_path", TypeName = "nvarchar(max)")]
        public string? ImagePath { get; set; }

        [ForeignKey("AlbumId")]
        [Column("album_id")]
        public int? AlbumId { get; set; }
        public Album? Album { get; set; }

        [Column("is_album_cover")]
        public bool? IsAlbumCover { get; set; }

        [Column("image_is_active")]
        public bool? ImageIsActive { get; set; }
    }

}
