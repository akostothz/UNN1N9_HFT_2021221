using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNN1N9_HFT_2021221.Models
{
    [Table("SONGS")]
    public class Song
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int SongID { get; set; }

        [Required]
        public int PerformancerID { get; set; }

        public int? AlbumID { get; set; }
        
        [Required]
        public string SongName { get; set; }

        [MaxLength(3)]
        [Required]
        public int Length { get; set; }

        [Required]
        public string Style { get; set; }

        [NotMapped]
        public virtual Artist Artist { get; set; }

        [NotMapped]
        public virtual Album Album { get; set; }

        [NotMapped]
        public string AllData => $"[{SongID}]: {SongName} BY ID OF {PerformancerID} >> (LENGTH: {Length}, STYLE: {Style})";
    }
}
