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
            Artist ar1 = new Artist() { ArtistID = 1, ArtistName = "Kid Cudi", NumberOfAlbums = 8, CountryOfOrigin = "USA" };
            Artist ar2 = new Artist() { ArtistID = 2, ArtistName = "Killstation", NumberOfAlbums = 2, CountryOfOrigin = "USA" };
            Artist ar3 = new Artist() { ArtistID = 3, ArtistName = "Marshmello", NumberOfAlbums = 4, CountryOfOrigin = "USA" };
            Artist ar4 = new Artist() { ArtistID = 4, ArtistName = "Joji", NumberOfAlbums = 3, CountryOfOrigin = "JAPAN" };
            Artist ar5 = new Artist() { ArtistID = 5, ArtistName = "Mac Demarco", NumberOfAlbums = 12, CountryOfOrigin = "CANADA"};
            Artist ar6 = new Artist() { ArtistID = 6, ArtistName = "The Neighbourhood", NumberOfAlbums = 5, CountryOfOrigin = "USA" };
            Artist ar7 = new Artist() { ArtistID = 7, ArtistName = "Stromae", NumberOfAlbums = 1, CountryOfOrigin = "FRANCE" };
            Artist ar8 = new Artist() { ArtistID = 8, ArtistName = "Ludovico Einaudi", NumberOfAlbums = 33, CountryOfOrigin = "ITALY" };
            Artist ar9 = new Artist() { ArtistID = 9, ArtistName = "AWS", NumberOfAlbums = 5, CountryOfOrigin = "HUNGARY" };
            Artist ar10 = new Artist() { ArtistID = 10, ArtistName = "MGMT", NumberOfAlbums = 5, CountryOfOrigin = "USA" };

            //album initialization
            Album al1 = new Album() { AlbumID = 1, AlbumName = "Man On the Moon: The End of Day", Style = "HIPHOP/RAP", Rating = 4.1, Year = 2008 };
            Album al2 = new Album() { AlbumID = 2, AlbumName = "The Two of Us Are Dying", Style = "ROCK", Rating = 8.3, Year = 2019 };
            Album al3 = new Album() { AlbumID = 3, AlbumName = "Shockwave", Style = "DANCE", Rating = 3.5, Year = 2021 };
            Album al4 = new Album() { AlbumID = 4, AlbumName = "BALLADS 1", Style = "R&B AND SOUL", Rating = 6.7, Year = 2018 };
            Album al5 = new Album() { AlbumID = 5, AlbumName = "Nectar", Style = "ALTERNATIVE", Rating = 8.1, Year = 2020 };
            Album al6 = new Album() { AlbumID = 6, AlbumName = "This Old Dog", Style = "INDIE ROCK", Rating = 9.2, Year = 2017 };
            Album al7 = new Album() { AlbumID = 7, AlbumName = "#000000 & #FFFFFF", Style = "ALTERNATIVE", Rating = 7.4, Year = 2014 };
            Album al8 = new Album() { AlbumID = 8, AlbumName = "Cheese", Style = "DANCE", Rating = 8.2, Year = 2010 };
            Album al9 = new Album() { AlbumID = 9, AlbumName = "In a Time Lapse", Style = "CLASSICAL", Rating = 10, Year = 2013 };
            Album al10 = new Album() { AlbumID = 10, AlbumName = "Kint a vízből", Style = "METAL", Rating = 6.8, Year = 2016 };
            Album al11 = new Album() { AlbumID = 11, AlbumName = "Little Dark Age", Style = "ALTERNATIVE", Rating = 9.8, Year = 2017 };
            Album al12 = new Album() { AlbumID = 12, AlbumName = "Oracular Spectacular", Style = "ALTERNATIVE", Rating = 8.7, Year = 2007 };

            //song initialization
            Song s1 = new Song() { SongID = 1, SongName = "SLOW DANCING IN THE DARK", Style = "R&B AND SOUL", Length = 4, IsExplicit = true, IsLoveSong = true };
            Song s2 = new Song() { SongID = 2, SongName = "YEAH RIGHT", Style = "R&B AND SOUL", Length = 3, IsExplicit = true, IsLoveSong = true };
            Song s3 = new Song() { SongID = 3, SongName = "Gimme Love", Style = "ALTERNATIVE", Length = 3, IsExplicit = false, IsLoveSong = true };
            Song s4 = new Song() { SongID = 4, SongName = "Shockwave", Style = "DANCE", Length = 3, IsExplicit = false, IsLoveSong = false };
            Song s5 = new Song() { SongID = 5, SongName = "Extinction", Style = "ROCK", Length = 1, IsExplicit = false, IsLoveSong = false };
            Song s6 = new Song() { SongID = 6, SongName = "Sarcoma", Style = "ROCK", Length = 3, IsExplicit = false, IsLoveSong = true };
            Song s7 = new Song() { SongID = 7, SongName = "Attraction", Style = "ROCK", Length = 4, IsExplicit = true, IsLoveSong = true };
            Song s8 = new Song() { SongID = 8, SongName = "Day 'n' Nite", Style = "HIPHOP/RAP", Length = 5, IsExplicit = false, IsLoveSong = false };
            Song s9 = new Song() { SongID = 9, SongName = "For the First Time", Style = "ALTERNATIVE", Length = 3, IsExplicit = false, IsLoveSong = true };
            Song s10 = new Song() { SongID = 10, SongName = "Unfair", Style = "ALTERNATIVE", Length = 2, IsExplicit = false, IsLoveSong = true };
            Song s11 = new Song() { SongID = 11, SongName = "#icanteven", Style = "ALTERNATIVE", Length = 5, IsExplicit = true, IsLoveSong = true };
            Song s12 = new Song() { SongID = 12, SongName = "Alors on danse", Style = "DANCE", Length = 4, IsExplicit = false, IsLoveSong = false };
            Song s13 = new Song() { SongID = 13, SongName = "Bienvenue chez moi", Style = "DANCE", Length = 3, IsExplicit = true, IsLoveSong = true };
            Song s14 = new Song() { SongID = 14, SongName = "Experience", Style = "CLASSICAL", Length = 6, IsExplicit = false, IsLoveSong = false };
            Song s15 = new Song() { SongID = 15, SongName = "Lelket vennék", Style = "METAL", Length = 3, IsExplicit = true, IsLoveSong = false };
            Song s16 = new Song() { SongID = 16, SongName = "Édes mint a só", Style = "LIGHT ROCK", Length = 3, IsExplicit = false, IsLoveSong = true };
            Song s17 = new Song() { SongID = 17, SongName = "Kén, higany, só", Style = "METAL", Length = 4, IsExplicit = true, IsLoveSong = false };
            Song s18 = new Song() { SongID = 18, SongName = "Little Dark Age", Style = "ALTERNATIVE", Length = 5, IsExplicit = false, IsLoveSong = false };
            Song s19 = new Song() { SongID = 19, SongName = "Electric Feel", Style = "ALTERNATIVE", Length = 4, IsExplicit = false, IsLoveSong = true };
            Song s20 = new Song() { SongID = 20, SongName = "Kids", Style = "ALTERNATIVE", Length = 4, IsExplicit = true, IsLoveSong = false };

            #endregion


            #region CONNECTIONS

            al1.ArtistID = ar1.ArtistID;
            al2.ArtistID = ar2.ArtistID;
            al3.ArtistID = ar3.ArtistID;
            al5.ArtistID = ar4.ArtistID;
            al4.ArtistID = ar4.ArtistID;
            al6.ArtistID = ar5.ArtistID;
            al7.ArtistID = ar6.ArtistID;
            al8.ArtistID = ar7.ArtistID;
            al9.ArtistID = ar8.ArtistID;
            al10.ArtistID = ar9.ArtistID;
            al11.ArtistID = ar10.ArtistID;
            al12.ArtistID = ar10.ArtistID;

            s8.AlbumID = al1.AlbumID;
            s7.AlbumID = al2.AlbumID;
            s6.AlbumID = al2.AlbumID;
            s5.AlbumID = al2.AlbumID;
            s4.AlbumID = al3.AlbumID;
            s3.AlbumID = al5.AlbumID;
            s2.AlbumID = al4.AlbumID;
            s1.AlbumID = al4.AlbumID;
            s9.AlbumID = al6.AlbumID;
            s10.AlbumID = al7.AlbumID;
            s11.AlbumID = al7.AlbumID;
            s12.AlbumID = al8.AlbumID;
            s13.AlbumID = al8.AlbumID;
            s14.AlbumID = al9.AlbumID;
            s15.AlbumID = al10.AlbumID;
            s16.AlbumID = al10.AlbumID;
            s17.AlbumID = al10.AlbumID;
            s18.AlbumID = al11.AlbumID;
            s19.AlbumID = al12.AlbumID;
            s20.AlbumID = al12.AlbumID;

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
            
            modelBuilder.Entity<Artist>().HasData(ar1, ar2, ar3, ar4, ar5, ar6, ar7, ar8, ar9, ar10);
            modelBuilder.Entity<Album>().HasData(al1, al2, al3, al4, al5, al6, al7, al8, al9, al10, al11, al12);
            modelBuilder.Entity<Song>().HasData(s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16, s17, s18, s19, s20);

            #endregion
        }
    }
}
