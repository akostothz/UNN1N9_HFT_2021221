using ConsoleTools;
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

            var menu = new ConsoleMenu()
                .Add(">> CREATE", () => Create(rest))
                .Add(">> READ ONE", () => ReadOne(rest))
                .Add(">> READ ALL", () => ReadAll(rest))
                .Add(">> UPDATE", () => Update(rest))
                .Add(">> DELETE", () => Delete(rest))
                .Add(">> EXIT", ConsoleMenu.Close);

            menu.Show();

            var artists = rest.Get<Artist>("artist");

            Console.ReadKey();
        }
        private static void Create(RestService rest)
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("What type of record do you want to create?");
            Console.WriteLine("\n");
            Console.WriteLine("[0] >> ARTIST");
            Console.WriteLine("[1] >> ALBUM");
            Console.WriteLine("[2] >> SONG");
            Console.WriteLine("\n\n");
            Console.WriteLine("[TYPE YOUR ANSWER..] >> ");

            int readin = 0;
            try
            {
                readin = int.Parse(Console.ReadLine());               
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("[ERROR] >> YOUR ANSWER MUST BE BETWEEN 0 AND 2");
            }
            Console.Clear();

            if (readin == 0)
            {
                Console.WriteLine("[CREATE AN ARTIST]");
                Console.WriteLine("\n\n");

                Console.Write("[NAME] >> ");
                string aName = Console.ReadLine();
                Console.WriteLine("\n\n");

                Console.Write("[COUNTRY OF ORIGIN] >> ");
                string cOfOrigin = Console.ReadLine();
                Console.WriteLine("\n\n");

                Console.Write("[NUMBER OF ALBUMS] >> ");
                int noOfAlbums = int.Parse(Console.ReadLine());
                Console.WriteLine("\n\n");

                rest.Post<Artist>(new Artist()
                {
                    ArtistName = aName,
                    CountryOfOrigin = cOfOrigin,
                    NumberOfAlbums = noOfAlbums
                }, "artist");

                Console.WriteLine("\n\n\n\n");
                Console.WriteLine("[ARTIST CREATED SUCCESFULLY]");
            }
            else if (readin == 1)
            {
                Console.WriteLine("[CREATE AN ALBUM]");
                Console.WriteLine("\n\n");

                Console.Write("[NAME] >> ");
                string aName = Console.ReadLine();
                Console.WriteLine("\n\n");

                Console.Write("[YEAR] >> ");
                int year = int.Parse(Console.ReadLine());
                Console.WriteLine("\n\n");

                Console.Write("[RATING] >> ");
                double rating = double.Parse(Console.ReadLine());
                Console.WriteLine("\n\n");

                Console.Write("[STYLE] >> ");
                string style = Console.ReadLine();
                Console.WriteLine("\n\n");

                Console.Write("[ARTIST ID] >> ");
                int aID = int.Parse(Console.ReadLine());
                Console.WriteLine("\n\n");

                rest.Post<Album>(new Album()
                {
                    AlbumName = aName,
                    Year = year,
                    Style = style,
                    Rating = rating,
                    ArtistID = aID
                }, "album");

                Console.WriteLine("\n\n\n\n");
                Console.WriteLine("[ALBUM CREATED SUCCESFULLY]");
            }
            else if (readin == 2)
            {
                Console.WriteLine("[CREATE A SONG]");
                Console.WriteLine("\n\n");

                Console.Write("[NAME] >> ");
                string sName = Console.ReadLine();
                Console.WriteLine("\n\n");

                Console.Write("[STYLE] >> ");
                string style = Console.ReadLine();
                Console.WriteLine("\n\n");

                Console.Write("[LENGTH] >> ");
                int length = int.Parse(Console.ReadLine());
                Console.WriteLine("\n\n");

                Console.Write("[IS IT EXPLICIT? (Y/N)] >> ");
                char response = char.Parse(Console.ReadLine());
                bool isEx = false;
                if (response.Equals('Y')) { isEx = true; }
                Console.WriteLine("\n\n");

                Console.Write("[IS IT A LOVE SONG? (Y/N)] >> ");
                char response2 = char.Parse(Console.ReadLine());
                bool isLS = false;
                if (response2.Equals('Y')) { isLS = true; }
                Console.WriteLine("\n\n");

                Console.Write("[ALBUM ID] >> ");
                int aID = int.Parse(Console.ReadLine());
                Console.WriteLine("\n\n");

                rest.Post<Song>(new Song()
                {
                    SongName = sName,
                    Style = style,
                    Length = length,
                    IsExplicit = isEx,
                    IsLoveSong = isLS,
                    AlbumID = aID
                }, "song");

                Console.WriteLine("\n\n\n\n");
                Console.WriteLine("[SONG CREATED SUCCESFULLY]");
            }

            Console.ReadLine();
        }
        private static void ReadOne(RestService rest)
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("What type of record do you want to get?");
            Console.WriteLine("\n");
            Console.WriteLine("[0] >> ARTIST");
            Console.WriteLine("[1] >> ALBUM");
            Console.WriteLine("[2] >> SONG");
            Console.WriteLine("\n\n");
            Console.WriteLine("[TYPE YOUR ANSWER..] >> ");

            int readin = 0;
            try
            {
                readin = int.Parse(Console.ReadLine());
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("[ERROR] >> YOUR ANSWER MUST BE BETWEEN 0 AND 2");
            }

            Console.Clear();
            Console.Write("[INDEX] >> ");
            int idx = int.Parse(Console.ReadLine());
            Console.WriteLine("\n\n");

            if (readin == 0)
            {
                var artist = rest.GetSingle<Artist>($"artist/{idx}");

                Console.WriteLine($"[ID] >> {artist.ArtistID}");
                Console.WriteLine($"[NAME] >> {artist.ArtistName}");
                Console.WriteLine($"[COUNTRY OF ORIGIN] >> {artist.CountryOfOrigin}");
                Console.WriteLine($"[NUMBER OF ALBUMS] >> {artist.NumberOfAlbums}");
                Console.Write($"[ALBUMS BY '{artist.ArtistName}' IN DATABASE] >> ");
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (var item in artist.Albums)
                {                 
                    Console.Write(item.AlbumName);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
            else if (readin == 1)
            {
                var album = rest.GetSingle<Album>($"album/{idx}");

                Console.WriteLine($"[ID] >> {album.AlbumID}");
                Console.WriteLine($"[NAME] >> {album.AlbumName}");
                Console.WriteLine($"[ARTIST] >> {album.Artist.ArtistName}");
                Console.WriteLine($"[RATING] >> {album.Rating}");
                Console.WriteLine($"[YEAR] >> {album.Year}");
                Console.WriteLine($"[STYLE] >> {album.Style}");
                Console.Write($"[SONGS ON '{album.AlbumName}' IN DATABASE] >> ");
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (var item in album.Songs)
                {
                    Console.Write(item.SongName);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
            else if (readin == 2)
            {
                var song = rest.GetSingle<Song>($"song/{idx}");

                Console.WriteLine($"[ID] >> {song.SongID}");
                Console.WriteLine($"[NAME] >> {song.SongName}");
                Console.WriteLine($"[ARTIST] >> {song.Album.Artist.ArtistName}");
                Console.WriteLine($"[ALBUM] >> {song.Album.AlbumName}");
                Console.WriteLine($"[LENGTH] >> {song.Length}");
                Console.WriteLine($"[IS IS EXPLICIT?] >> {song.IsExplicit}");
                Console.WriteLine($"[IS IT A LOVESONG?] >> {song.IsExplicit}");
                Console.WriteLine($"[STYLE] >> {song.Style}");
            }

            Console.ReadLine();
        }
        private static void ReadAll(RestService rest)
        {

        }
        private static void Update(RestService rest)
        {

        }
        private static void Delete(RestService rest)
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            Console.WriteLine("What type of record do you want to delete?");
            Console.WriteLine("\n");
            Console.WriteLine("[0] >> ARTIST");
            Console.WriteLine("[1] >> ALBUM");
            Console.WriteLine("[2] >> SONG");
            Console.WriteLine("\n\n");
            Console.WriteLine("[TYPE YOUR ANSWER..] >> ");
           
            int readin = 0;
            try
            {
                readin = int.Parse(Console.ReadLine());
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("[ERROR] >> YOUR ANSWER MUST BE BETWEEN 0 AND 2");
            }
            Console.Clear();

            Console.Write("[INDEX] >> ");
            int idx = int.Parse(Console.ReadLine());
            Console.WriteLine("\n\n");

            if (readin == 0)
            {
                rest.Delete(idx, "artist");

                Console.WriteLine("\n\n\n\n");
                Console.WriteLine("[ARTIST DELETED SUCCESSFULLY]");
            }
            else if(readin == 1)
            {
                rest.Delete(idx, "album");

                Console.WriteLine("\n\n\n\n");
                Console.WriteLine("[ALBUM DELETED SUCCESSFULLY]");
            }
            else if(readin == 2)
            {
                rest.Delete(idx, "song");

                Console.WriteLine("\n\n\n\n");
                Console.WriteLine("[SONG DELETED SUCCESSFULLY]");
            }

            Console.ReadLine();
        }
    }
}
