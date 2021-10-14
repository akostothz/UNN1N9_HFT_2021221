using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNN1N9_HFT_2021221.Models;

namespace UNN1N9_HFT_2021221.Data
{
    public class MusicDbContext : DbContext
    {
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public MusicDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MyDatabase.mdf;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region INIT
            
            //artists
            Artist kidcudi = new Artist() 
            { 
                ArtistName = "Kid Cudi", 
                RealName = "Scott Ramon Seguro Mescudi", 
                Age = 37, 
                NumberOfAlbums = 8 
            };
            Artist killstation = new Artist() 
            { 
                ArtistName = "Killstation", 
                RealName = "Nolan Santana", 
                Age = 23, 
                NumberOfAlbums = 2 
            };
            Artist marshmello = new Artist() 
            { 
                ArtistName = "Marshmello", 
                RealName = "Christopher Cornstock", 
                Age = 29, 
                NumberOfAlbums = 4
            };
            Artist joji = new Artist() 
            { ArtistName = "Joji", 
                RealName = "George Kusunoki Miller", 
                Age = 29, 
                NumberOfAlbums = 3 
            };

            //albums
            Album manonthemoon = new Album()
            {
                AlbumName = "Man On the Moon: The End of Day",
                Artist = kidcudi,
                PerformancerID = kidcudi.ArtistID,
                Style = "HIPHOP/RAP",
                Year = 2009
            };
            Album indicud = new Album()
            {
                AlbumName = "Indicud",
                Artist = kidcudi,
                PerformancerID = kidcudi.ArtistID,
                Style = "HIPHOP/RAP",
                Year = 2013
            };
            Album thetwoofus = new Album()
            {
                AlbumName = "The Two of Us Are Dying",
                Artist = killstation,
                PerformancerID = killstation.ArtistID,
                Style = "ROCK",
                Year = 2019
            };
            Album xxii = new Album()
            {
                AlbumName = "XXII",
                Artist = killstation,
                PerformancerID = killstation.ArtistID,
                Style = "ALTERNATIVE",
                Year = 2021
            };
            Album shockwave = new Album()
            {
                AlbumName = "Shockwave",
                Artist = marshmello,
                PerformancerID = marshmello.ArtistID,
                Style = "DANCE",
                Year = 2021
            };
            Album joytime2 = new Album()
            {
                AlbumName = "Joytime II",
                Artist = marshmello,
                PerformancerID = marshmello.ArtistID,
                Style = "DANCE",
                Year = 2018
            };
            Album ballads1 = new Album()
            {
                AlbumName = "BALLADS 1",
                Artist = joji,
                PerformancerID = joji.ArtistID,
                Style = "R&B AND SOUL",
                Year = 2018
            };
            Album nectar = new Album()
            {
                AlbumName = "Nectar",
                Artist = joji,
                PerformancerID = joji.ArtistID,
                Style = "ALTERNATIVE",
                Year = 2020
            };
            #endregion
        }
    }
}
