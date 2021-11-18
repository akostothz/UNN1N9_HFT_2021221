using System;
using System.Collections.Generic;
using UNN1N9_HFT_2021221.Models;

namespace UNN1N9_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);
            RestService rest = new RestService("http://localhost:35739");

            //rest.Post<Artist>(new Artist()
            //{
            //    ArtistName = "Lil Uzi Vert", CountryOfOrigin = "USA", NumberOfAlbums = 4
            //}, "artist");

            //rest.Delete(13, "artist");
            //rest.Delete(12, "artist");
            //rest.Delete(11, "artist");

            var artists = rest.Get<Artist>("artist");

            Console.ReadKey();
        }
    }
}
