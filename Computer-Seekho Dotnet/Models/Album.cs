using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerSeekho.Models
{
   
        [Table("AlbumMaster")]
        public class Album
        {
            [Key]
            [Column("album_id")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int AlbumId { get; set; }

            [Column("album_name")]
            public string? AlbumName { get; set; }

            [Column("album_description")]
            public string? AlbumDescription { get; set; }

            [Column("start_date")]
            public DateTime? StartDate { get; set; }

            [Column("end_date")]
            public DateTime? EndDate { get; set; }

            [Column("album_is_active")]
            public bool? AlbumIsActive { get; set; }
        }
    }
