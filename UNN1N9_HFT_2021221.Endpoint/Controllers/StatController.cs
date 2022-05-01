﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UNN1N9_HFT_2021221.Logic;
using UNN1N9_HFT_2021221.Models;

namespace UNN1N9_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ISongLogic songLogic;
        IAlbumLogic albumLogic;

        public StatController(ISongLogic sLog, IAlbumLogic alLog)
        {
            this.songLogic = sLog;
            this.albumLogic = alLog;
        }

        // GET: /stat/avglengthbyalbums
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGLengthByAlbums()
        {
            return songLogic.AVGLengthByAlbums();
        }

        // GET: /stat/numberofexplicitsongsbyartists
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> NumberOfExplicitSongsByArtists()
        {
            return songLogic.NumberOfExplicitSongsByArtists();
        }

        // GET: /stat/lengthofallsongsbycountries
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> LengthOfAllSongsByCountries()
        {
            return songLogic.LengthOfAllSongsByCountries();
        }

        // GET: /stat/numberoflovesongsafter2015byartists
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> NumberOfLoveSongsAfter2015ByArtists()
        {
            return songLogic.NumberOfLoveSongsAfter2015ByArtists();
        }

        // GET: /stat/numberofalbumswbiggerratingthan8bycountries
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> NumberOfAlbumsWBiggerRatingThan8ByCountries()
        {
            return albumLogic.NumberOfAlbumsWBiggerRatingThan8ByCountries();
        }

        // GET: /stat/lovesongsfromusa
        [HttpGet]
        public IEnumerable<Song> LoveSongsFromUSA()
        {
            return songLogic.LoveSongsFromUSA();
        }

        // GET: /stat/explicitsongsafter2010
        [HttpGet]
        public IEnumerable<Song> ExplicitSongsAfter2010()
        {
            return songLogic.ExplicitSongsAfter2010();
        }

        // GET: /stat/alternativelovesongswithar7
        [HttpGet]
        public IEnumerable<Song> AlternativeLoveSongsWithAR7()
        {
            return songLogic.AlternativeLoveSongsWithAR7();
        }
    }
}
