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
           
            #endregion
        }
    }
}
