using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNN1N9_HFT_2021221.Models
{
    [Table("ALBUMS")]
    public class Album
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlbumID { get; set; }

        [Required]
        [ForeignKey(nameof(Models.Artist))]
        public virtual int ArtistID { get; set; }

        [Required]
        [MaxLength(150)]
        public string AlbumName { get; set; }

        [Required]
        public string Style { get; set; }

        public double Rating { get; set; }

        [Required]
        public int Year { get; set; }

        [NotMapped]
        public virtual Artist Artist { get; set; }

        public virtual ICollection<Song> Songs { get; set; }

        public Album()
        {
            Songs = new HashSet<Song>();
        }
    }
}
