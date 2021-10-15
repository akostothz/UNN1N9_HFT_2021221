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

            //artist initialization
            Artist ar1 = new Artist() { ArtistID = 1, ArtistName = "Kid Cudi", NumberOfAlbums = 8 };
            Artist ar2 = new Artist() { ArtistID = 2, ArtistName = "Killstation", NumberOfAlbums = 2 };
            Artist ar3 = new Artist() { ArtistID = 3, ArtistName = "Marshmello", NumberOfAlbums = 4 };
            Artist ar4 = new Artist() { ArtistID = 4, ArtistName = "Joji", NumberOfAlbums = 3
            };

            //album initialization
            Album al1 = new Album() { AlbumID = 1, AlbumName = "Man On the Moon: The End of Day", Style = "HIPHOP/RAP" };
            Album al2 = new Album() { AlbumID = 2, AlbumName = "The Two of Us Are Dying", Style = "ROCK" };
            Album al3 = new Album() { AlbumID = 3, AlbumName = "Shockwave", Style = "DANCE" };
            Album al4 = new Album() { AlbumID = 4, AlbumName = "BALLADS 1", Style = "R&B AND SOUL" };
            Album al5 = new Album() { AlbumID = 5, AlbumName = "Nectar", Style = "ALTERNATIVE" };

            //song initialization
            Song s1 = new Song() { SongID = 1, SongName = "SLOW DANCING IN THE DARK", Style = "R&B AND SOUL" };
            Song s2 = new Song() { SongID = 2, SongName = "YEAH RIGHT", Style = "R&B AND SOUL" };
            Song s3 = new Song() { SongID = 3, SongName = "Gimme Love", Style = "ALTERNATIVE" };
            Song s4 = new Song() { SongID = 4, SongName = "Shockwave", Style = "DANCE" };
            Song s5 = new Song() { SongID = 5, SongName = "Extinction", Style = "ROCK" };
            Song s6 = new Song() { SongID = 6, SongName = "Sarcoma", Style = "ROCK" };
            Song s7 = new Song() { SongID = 7, SongName = "Attraction", Style = "ROCK" };
            Song s8 = new Song() { SongID = 8, SongName = "Day 'n' Nite", Style = "HIPHOP/RAP" };

            #endregion


            #region CONNECTIONS

            al1.ArtistID = ar1.ArtistID;
            al2.ArtistID = ar2.ArtistID;
            al3.ArtistID = ar3.ArtistID;
            al5.ArtistID = ar4.ArtistID;
            al4.ArtistID = ar4.ArtistID;

            s8.AlbumID = al1.AlbumID;
            s7.AlbumID = al2.AlbumID;
            s6.AlbumID = al2.AlbumID;
            s5.AlbumID = al2.AlbumID;
            s4.AlbumID = al3.AlbumID;
            s3.AlbumID = al5.AlbumID;
            s2.AlbumID = al4.AlbumID;
            s1.AlbumID = al4.AlbumID;

            #endregion


            #region FLUENTAPI

            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasOne(album => album.Artist)
                        .WithMany(artist => artist.Albums)
                        .HasForeignKey(album => album.ArtistID)
                        .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.HasOne(song => song.Album)
                        .WithMany(album => album.Songs)
                        .HasForeignKey(song => song.AlbumID)
                        .OnDelete(DeleteBehavior.ClientSetNull);
            });
            
            modelBuilder.Entity<Artist>().HasData(ar1, ar2, ar3, ar4);
            modelBuilder.Entity<Album>().HasData(al1, al2, al3, al4, al5);
            modelBuilder.Entity<Song>().HasData(s1, s2, s3, s4, s5, s6, s7, s8);

            #endregion
        }
    }
}
