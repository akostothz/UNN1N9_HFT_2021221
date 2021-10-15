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
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArtistID { get; set; }

        [Required]
        [MaxLength(50)]
        public string ArtistName { get; set; }

        public int? NumberOfAlbums { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

        public Artist()
        {
            Albums = new HashSet<Album>();
        }
    }
}
