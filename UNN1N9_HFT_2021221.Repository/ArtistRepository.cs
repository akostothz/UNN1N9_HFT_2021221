using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNN1N9_HFT_2021221.Data;
using UNN1N9_HFT_2021221.Models;

namespace UNN1N9_HFT_2021221.Repository
{
    public class ArtistRepository : IArtistRepository
    {
        MusicDbContext dbCon;
        public ArtistRepository(MusicDbContext dbCon) 
        {
            this.dbCon = dbCon;
        }

        #region CRUDmethods
        public void Create(Artist artist)
        {
            dbCon.Artists.Add(artist);
            dbCon.SaveChanges();
        }

        public Artist Read(int id)
        {
            return dbCon.Artists.FirstOrDefault(a => a.ArtistID == id);
        }

        public IQueryable<Artist> ReadAll()
        {
            return dbCon.Artists;
        }

        public void Update(Artist artist)
        {
            Artist oldArtist = Read(artist.ArtistID);
            oldArtist.ArtistName = artist.ArtistName;
            oldArtist.NumberOfAlbums = artist.NumberOfAlbums;
            oldArtist.CountryOfOrigin = artist.CountryOfOrigin;
            dbCon.SaveChanges();
        }

        public void Delete(int id)
        {
            dbCon.Remove(Read(id));
            dbCon.SaveChanges();
        }
        #endregion
    }
}
