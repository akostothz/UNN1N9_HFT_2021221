using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNN1N9_HFT_2021221.Models
{
    [Table("ARTISTS")]
    public class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ArtistID { get; set; }

        [Required]
        [MaxLength(40)]
        public string ArtistName { get; set; }

        [MaxLength(150)]
        public string RealName { get; set; }

        [MaxLength(3)]
        public int? Age { get; set; }

        [MaxLength(3)]
        public int? NumberOfAlbums { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

        public Artist()
        {
            Albums = new HashSet<Album>();
        }
    }
}
