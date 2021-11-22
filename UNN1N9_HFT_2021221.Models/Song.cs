using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UNN1N9_HFT_2021221.Models
{
    [Table("SONGS")]
    public class Song
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int SongID { get; set; }

        [Required]
        [ForeignKey(nameof(Models.Album))]
        public virtual int AlbumID { get; set; }

        [Required]
        public string SongName { get; set; }

        [Required]
        public string Style { get; set; }

        [Required]
        public int Length { get; set; }

        [Required]
        public bool IsExplicit { get; set; }

        [Required]
        public bool IsLoveSong { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Album Album { get; set; }

    }
}
