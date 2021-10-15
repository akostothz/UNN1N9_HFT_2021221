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
            Album shockwave = new Album()
            {
                AlbumName = "Shockwave",
                Artist = marshmello,
                PerformancerID = marshmello.ArtistID,
                Style = "DANCE",
                Year = 2021
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

            //songs
            Song s1 = new Song()
            {
                SongName = "SLOW DANCING IN THE DARK",
                PerformancerID = joji.ArtistID,
                AlbumID = ballads1.AlbumID,
                Length = 3,
                Style = ballads1.Style,
                Artist = ballads1.Artist,
                Album = ballads1
            };
            Song s2 = new Song()
            {
                SongName = "YEAH RIGHT",
                PerformancerID = joji.ArtistID,
                AlbumID = ballads1.AlbumID,
                Length = 3,
                Style = ballads1.Style,
                Artist = ballads1.Artist,
                Album = ballads1
            };
            Song s3 = new Song()
            {
                SongName = "Gimme Love",
                PerformancerID = joji.ArtistID,
                AlbumID = nectar.AlbumID,
                Length = 4,
                Style = nectar.Style,
                Artist = nectar.Artist,
                Album = nectar
            };
            Song s4 = new Song()
            {
                SongName = "Shockwave",
                PerformancerID = marshmello.ArtistID,
                AlbumID = shockwave.AlbumID,
                Length = 3,
                Style = shockwave.Style,
                Artist = shockwave.Artist,
                Album = shockwave
            };
            Song s5 = new Song()
            {
                SongName = "Extinction",
                PerformancerID = killstation.ArtistID,
                Length = 1,
                Style = "METALLIC",
                Artist = killstation
            };
            Song s6 = new Song()
            {
                SongName = "Sarcoma",
                PerformancerID = killstation.ArtistID,
                AlbumID = thetwoofus.AlbumID,
                Length = 2,
                Style = thetwoofus.Style,
                Artist = thetwoofus.Artist,
                Album = thetwoofus
            };
            Song s7 = new Song()
            {
                SongName = "Attraction",
                PerformancerID = killstation.ArtistID,
                AlbumID = thetwoofus.AlbumID,
                Length = 3,
                Style = thetwoofus.Style,
                Artist = thetwoofus.Artist,
                Album = thetwoofus
            };
            Song s8 = new Song()
            {
                SongName = "Day 'n' Nite",
                PerformancerID = kidcudi.ArtistID,
                AlbumID = manonthemoon.AlbumID,
                Length = 4,
                Style = manonthemoon.Style,
                Artist = manonthemoon.Artist,
                Album = manonthemoon
            };
            #endregion

        }
    }
}
