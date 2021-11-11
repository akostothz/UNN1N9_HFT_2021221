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
    public class SongRepository : ISongRepository
    {
        MusicDbContext dbCon;
        public SongRepository(MusicDbContext dbCon)
        {
            this.dbCon = dbCon;
        }

        #region CRUDmethods
        public void Create(Song song)
        {
            dbCon.Songs.Add(song);
            dbCon.SaveChanges();
        }

        public Song Read(int id)
        {
            return dbCon.Songs.FirstOrDefault(s => s.SongID == id);
        }

        public IQueryable<Song> ReadAll()
        {
            return dbCon.Songs;
        }

        public void Update(Song song)
        {
            Song oldSong = Read(song.SongID);
            oldSong.SongName = song.SongName;
            oldSong.Style = song.Style;
            oldSong.AlbumID = song.AlbumID;
            oldSong.Length = song.Length;
            oldSong.IsExplicit = song.IsExplicit;
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
