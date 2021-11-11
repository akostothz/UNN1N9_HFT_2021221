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
    public class AlbumRepository : IAlbumRepository
    {
        MusicDbContext dbCon;
        public AlbumRepository(MusicDbContext dbCon)
        {
            this.dbCon = dbCon;
        }

        #region CRUDmethods
        public void Create(Album album)
        {
            dbCon.Albums.Add(album);
            dbCon.SaveChanges();
        }

        public Album Read(int id)
        {
            return dbCon.Albums.FirstOrDefault(a => a.AlbumID == id);
        }

        public IQueryable<Album> ReadAll()
        {
            return dbCon.Albums;
        }

        public void Update(Album album)
        {
            Album oldAlbum = Read(album.AlbumID);
            oldAlbum.AlbumName = album.AlbumName;
            oldAlbum.Style = album.Style;
            oldAlbum.ArtistID = album.ArtistID;
            oldAlbum.Rating = album.Rating;
            oldAlbum.Year = album.Year;
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
