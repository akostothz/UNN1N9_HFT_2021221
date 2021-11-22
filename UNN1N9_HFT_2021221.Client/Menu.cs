using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNN1N9_HFT_2021221.Models;

namespace UNN1N9_HFT_2021221.Client
{
    class Menu
    {
        public static void Start(RestService rest)
        {
            Console.ForegroundColor = ConsoleColor.White;
            var menu = new ConsoleMenu()
                .Add(" >> CREATE", () => Create(rest))
                .Add(" >> READ ONE", () => ReadOne(rest))
                .Add(" >> READ ALL", () => ReadAll(rest))
                .Add(" >> UPDATE", () => Update(rest))
                .Add(" >> DELETE", () => Delete(rest))
                .Add(" >> AVG LENGTH BY ALBUMS", () => AVGLengthByAlbums(rest))
                .Add(" >> NUMBER OF EXPL. SONGS BY ARTISTS", () => NumberOfExplSongsByArtists(rest))
                .Add(" >> LENGTH OF ALL SONGS BY COUNTRIES", () => LengthOfAllSongsByCountries(rest))
                .Add(" >> NUMBER OF LOVE SONGS AFTER 2015 BY ARTISTS", () => NumberOfLoveSongsA2015ByArtists(rest))
                .Add(" >> NUMBER OF ALBUMS WITH BIGGER RATING THAN 8 BY COUNTRIES", () => NumberOfAlbumsRating8ByCountries(rest))
                .Add(">> EXIT", ConsoleMenu.Close);

            menu.Show();
        }

        #region CRUD

        private static void Create(RestService rest)
        {
            Console.Clear();
            Console.WriteLine("[CREATE]");
            Console.WriteLine("\n");
            Console.WriteLine("What type of record do you want to create?");
            Console.WriteLine("\n");
            Console.WriteLine("[0] >> ARTIST");
            Console.WriteLine("[1] >> ALBUM");
            Console.WriteLine("[2] >> SONG");
            Console.WriteLine("\n");
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
                Console.WriteLine("\n");

                Console.Write("[COUNTRY OF ORIGIN] >> ");
                string cOfOrigin = Console.ReadLine();
                Console.WriteLine("\n");

                Console.Write("[NUMBER OF ALBUMS] >> ");
                int noOfAlbums = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");

                rest.Post<Artist>(new Artist()
                {
                    ArtistName = aName,
                    CountryOfOrigin = cOfOrigin,
                    NumberOfAlbums = noOfAlbums
                }, "artist");

                Console.WriteLine("\n\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[ARTIST CREATED SUCCESFULLY]");
            }
            else if (readin == 1)
            {
                Console.WriteLine("[CREATE AN ALBUM]");
                Console.WriteLine("\n\n");

                Console.Write("[NAME] >> ");
                string aName = Console.ReadLine();
                Console.WriteLine("\n");

                Console.Write("[YEAR] >> ");
                int year = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");

                Console.Write("[RATING] >> ");
                double rating = double.Parse(Console.ReadLine());
                Console.WriteLine("\n");

                Console.Write("[STYLE] >> ");
                string style = Console.ReadLine();
                Console.WriteLine("\n");

                Console.Write("[ARTIST ID] >> ");
                int aID = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");

                rest.Post<Album>(new Album()
                {
                    AlbumName = aName,
                    Year = year,
                    Style = style,
                    Rating = rating,
                    ArtistID = aID
                }, "album");

                Console.WriteLine("\n\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[ALBUM CREATED SUCCESFULLY]");
            }
            else if (readin == 2)
            {
                Console.WriteLine("[CREATE A SONG]");
                Console.WriteLine("\n\n");

                Console.Write("[NAME] >> ");
                string sName = Console.ReadLine();
                Console.WriteLine("\n");

                Console.Write("[STYLE] >> ");
                string style = Console.ReadLine();
                Console.WriteLine("\n");

                Console.Write("[LENGTH] >> ");
                int length = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");

                Console.Write("[IS IT EXPLICIT? (Y/N)] >> ");
                string response = Console.ReadLine();
                Console.WriteLine("\n");

                Console.Write("[IS IT A LOVE SONG? (Y/N)] >> ");
                string response2 = Console.ReadLine();

                Console.WriteLine("\n");

                Console.Write("[ALBUM ID] >> ");
                int aID = int.Parse(Console.ReadLine());
                Console.WriteLine("\n\n");

                rest.Post<Song>(new Song()
                {
                    SongName = sName,
                    Style = style,
                    Length = length,
                    IsExplicit = IsExplicitChecker(response),
                    IsLoveSong = IsLoveSongChecker(response2),
                    AlbumID = aID
                }, "song");

                Console.WriteLine("\n\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[SONG CREATED SUCCESFULLY]");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        private static bool IsLoveSongChecker(string response2)
        {
            if (response2.ToUpper().Equals("Y"))
            {
                return true;
            }
            else { return false; }
        }

        private static bool IsExplicitChecker(string response)
        {
            if (response.ToUpper().Equals("Y"))
            {
                return true;
            }
            else { return false; }
        }

        private static void ReadOne(RestService rest)
        {
            Console.Clear();
            Console.WriteLine("[READONE]");
            Console.WriteLine("\n");
            Console.WriteLine("What type of record do you want to get?");
            Console.WriteLine("\n");
            Console.WriteLine("[0] >> ARTIST");
            Console.WriteLine("[1] >> ALBUM");
            Console.WriteLine("[2] >> SONG");
            Console.WriteLine("\n");
            Console.Write("[TYPE YOUR ANSWER..] >> ");

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
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"[ID] >> {artist.ArtistID}");
                Console.WriteLine($"[NAME] >> {artist.ArtistName}");
                Console.WriteLine($"[COUNTRY OF ORIGIN] >> {artist.CountryOfOrigin}");
                Console.WriteLine($"[NUMBER OF ALBUMS] >> {artist.NumberOfAlbums}");
                Console.Write($"[ALBUMS BY '{artist.ArtistName}' IN DATABASE] >> ");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var item in artist.Albums)
                {
                    Console.WriteLine("\t" + item.AlbumName);
                }
            }
            else if (readin == 1)
            {
                var album = rest.GetSingle<Album>($"album/{idx}");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"[ID] >> {album.AlbumID}");
                Console.WriteLine($"[NAME] >> {album.AlbumName}");
                Console.WriteLine($"[RATING] >> {album.Rating}");
                Console.WriteLine($"[YEAR] >> {album.Year}");
                Console.WriteLine($"[STYLE] >> {album.Style}");
                Console.Write($"[SONGS ON '{album.AlbumName}' IN DATABASE] >> ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine();

                foreach (var item in album.Songs)
                {
                    Console.WriteLine("\t" + item.SongName);
                }
            }
            else if (readin == 2)
            {
                var song = rest.GetSingle<Song>($"song/{idx}");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"[ID] >> {song.SongID}");
                Console.WriteLine($"[NAME] >> {song.SongName}");
                Console.WriteLine($"[LENGTH] >> {song.Length}");
                Console.WriteLine($"[IS IS EXPLICIT?] >> {song.IsExplicit}");
                Console.WriteLine($"[IS IT A LOVESONG?] >> {song.IsLoveSong}");
                Console.WriteLine($"[STYLE] >> {song.Style}");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }
        private static void ReadAll(RestService rest)
        {
            Console.Clear();
            Console.WriteLine("[READALL]");
            Console.WriteLine("\n");
            Console.WriteLine("What type of record do you want to get?");
            Console.WriteLine("\n");
            Console.WriteLine("[0] >> ARTIST");
            Console.WriteLine("[1] >> ALBUM");
            Console.WriteLine("[2] >> SONG");
            Console.WriteLine("[3] >> ALL");
            Console.WriteLine("\n");
            Console.Write("[TYPE YOUR ANSWER..] >> ");

            int readin = 0;
            try
            {
                readin = int.Parse(Console.ReadLine());
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("[ERROR] >> YOUR ANSWER MUST BE BETWEEN 0 AND 3");
            }
            Console.Clear();

            if (readin == 0) //artist listing
            {
                var artists = rest.Get<Artist>($"artist");
                Console.WriteLine("LIST OF ARTISTS:\n");
                foreach (var artist in artists)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"[ID] >> {artist.ArtistID}");
                    Console.WriteLine($"[NAME] >> {artist.ArtistName}");
                    Console.WriteLine($"[COUNTRY OF ORIGIN] >> {artist.CountryOfOrigin}");
                    Console.WriteLine($"[NUMBER OF ALBUMS] >> {artist.NumberOfAlbums}");
                    Console.WriteLine("\n");
                }
            }
            else if (readin == 1) //album listing
            {
                var albums = rest.Get<Album>($"album");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("LIST OF ALBUMS:\n");
                Console.ForegroundColor = ConsoleColor.Cyan;

                foreach (var album in albums)
                {
                    Console.WriteLine($"[ID] >> {album.AlbumID}");
                    Console.WriteLine($"[NAME] >> {album.AlbumName}");
                    Console.WriteLine($"[RATING] >> {album.Rating}");
                    Console.WriteLine($"[YEAR] >> {album.Year}");
                    Console.WriteLine($"[STYLE] >> {album.Style}");
                    Console.WriteLine("\n");
                }

            }
            else if (readin == 2) //song listing
            {
                var songs = rest.Get<Song>($"song");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("LIST OF SONGS:\n");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                foreach (var song in songs)
                {
                    Console.WriteLine($"[ID] >> {song.SongID}");
                    Console.WriteLine($"[NAME] >> {song.SongName}");
                    Console.WriteLine($"[LENGTH] >> {song.Length}");
                    Console.WriteLine($"[IS IS EXPLICIT?] >> {song.IsExplicit}");
                    Console.WriteLine($"[IS IT A LOVESONG?] >> {song.IsLoveSong}");
                    Console.WriteLine($"[STYLE] >> {song.Style}");
                    Console.WriteLine("\n");
                }
            }
            else if (readin == 3) //listing all
            {
                var artists = rest.Get<Artist>($"artist");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("THE WHOLE DATABASE:\n");

                foreach (var artist in artists)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"[ID] >> {artist.ArtistID}");
                    Console.WriteLine($"[NAME] >> {artist.ArtistName}");
                    Console.WriteLine($"[COUNTRY OF ORIGIN] >> {artist.CountryOfOrigin}");
                    Console.WriteLine($"[NUMBER OF ALBUMS] >> {artist.NumberOfAlbums}");
                    Console.WriteLine("\n");
                    Console.Write($"[ALBUMS BY '{artist.ArtistName}' IN DATABASE] >> ");
                    Console.WriteLine("\n");

                    foreach (var album in artist.Albums)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"\t[ID] >> {album.AlbumID}");
                        Console.WriteLine($"\t[NAME] >> {album.AlbumName}");
                        Console.WriteLine($"\t[RATING] >> {album.Rating}");
                        Console.WriteLine($"\t[YEAR] >> {album.Year}");
                        Console.WriteLine($"\t[STYLE] >> {album.Style}");
                        Console.WriteLine("\n");
                        Console.Write($"\t[SONGS ON '{album.AlbumName}' IN DATABASE] >> ");
                        Console.WriteLine("\n");

                        foreach (var song in album.Songs)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine($"\t\t[ID] >> {song.SongID}");
                            Console.WriteLine($"\t\t[NAME] >> {song.SongName}");
                            Console.WriteLine($"\t\t[LENGTH] >> {song.Length}");
                            Console.WriteLine($"\t\t[IS IS EXPLICIT?] >> {song.IsExplicit}");
                            Console.WriteLine($"\t\t[IS IT A LOVESONG?] >> {song.IsLoveSong}");
                            Console.WriteLine($"\t\t[STYLE] >> {song.Style}");
                            Console.WriteLine("\n");
                        }
                    }
                    Console.WriteLine("\n");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }
        private static void Update(RestService rest)
        {
            Console.Clear();
            Console.WriteLine("[UPDATE]");
            Console.WriteLine("\n");
            Console.WriteLine("What type of record do you want to update?");
            Console.WriteLine("\n");
            Console.WriteLine("[0] >> ARTIST");
            Console.WriteLine("[1] >> ALBUM");
            Console.WriteLine("[2] >> SONG");
            Console.WriteLine("\n");
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
                Console.WriteLine("[UPDATE AN ARTIST]");
                Console.WriteLine("\n\n");

                Console.Write("[ID] >> ");
                int Id = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");

                Console.Write("[NEW NAME] >> ");
                string aName = Console.ReadLine();
                Console.WriteLine("\n");

                Console.Write("[NEW COUNTRY OF ORIGIN] >> ");
                string cOfOrigin = Console.ReadLine();
                Console.WriteLine("\n");

                Console.Write("[NEW NUMBER OF ALBUMS] >> ");
                int noOfAlbums = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");

                rest.Put<Artist>(new Artist()
                {
                    ArtistID = Id,
                    ArtistName = aName,
                    CountryOfOrigin = cOfOrigin,
                    NumberOfAlbums = noOfAlbums
                }, "artist");

                Console.WriteLine("\n\n\n\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[ARTIST UPDATED SUCCESFULLY]");
            }
            else if (readin == 1)
            {
                Console.WriteLine("[UPDATE AN ALBUM]");
                Console.WriteLine("\n\n");

                Console.Write("[ID] >> ");
                int Id = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");

                Console.Write("[NEW NAME] >> ");
                string aName = Console.ReadLine();
                Console.WriteLine("\n");

                Console.Write("[NEW YEAR] >> ");
                int year = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");

                Console.Write("[NEW RATING] >> ");
                double rating = double.Parse(Console.ReadLine());
                Console.WriteLine("\n");

                Console.Write("[NEW STYLE] >> ");
                string style = Console.ReadLine();
                Console.WriteLine("\n");

                Console.Write("[NEW ARTIST ID] >> ");
                int aID = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");

                rest.Put<Album>(new Album()
                {
                    AlbumID = Id,
                    AlbumName = aName,
                    Year = year,
                    Style = style,
                    Rating = rating,
                    ArtistID = aID
                }, "album");

                Console.WriteLine("\n\n\n\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[ALBUM UPDATED SUCCESFULLY]");
            }
            else if (readin == 2)
            {
                Console.WriteLine("[UPDATE A SONG]");
                Console.WriteLine("\n\n");

                Console.Write("[ID] >> ");
                int Id = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");

                Console.Write("[NEW NAME] >> ");
                string sName = Console.ReadLine();
                Console.WriteLine("\n");

                Console.Write("[NEW STYLE] >> ");
                string style = Console.ReadLine();
                Console.WriteLine("\n");

                Console.Write("[NEW LENGTH] >> ");
                int length = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");

                Console.Write("[NEW IS IT EXPLICIT? (Y/N)] >> ");
                char response = char.Parse(Console.ReadLine());
                bool isEx = false;
                if (response.Equals('Y')) { isEx = true; }
                Console.WriteLine("\n");

                Console.Write("[NEW IS IT A LOVE SONG? (Y/N)] >> ");
                char response2 = char.Parse(Console.ReadLine());
                bool isLS = false;
                if (response2.Equals('Y')) { isLS = true; }
                Console.WriteLine("\n");

                Console.Write("[NEW ALBUM ID] >> ");
                int aID = int.Parse(Console.ReadLine());
                Console.WriteLine("\n\n");

                rest.Put<Song>(new Song()
                {
                    //SongID = rest.GetSingle<Song>($"song/{Id}").SongID,
                    SongName = sName,
                    Style = style,
                    Length = length,
                    IsExplicit = isEx,
                    IsLoveSong = isLS,
                    AlbumID = aID
                }, "song");

                Console.WriteLine("\n\n\n\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[SONG UPDATED SUCCESFULLY]");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }
        private static void Delete(RestService rest)
        {
            Console.Clear();
            Console.WriteLine("[DELETE]");
            Console.WriteLine("\n");
            Console.WriteLine("What type of record do you want to delete?");
            Console.WriteLine("\n");
            Console.WriteLine("[0] >> ARTIST");
            Console.WriteLine("[1] >> ALBUM");
            Console.WriteLine("[2] >> SONG");
            Console.WriteLine("\n");
            Console.Write("[TYPE YOUR ANSWER..] >> ");

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
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("[ARTIST DELETED SUCCESSFULLY]");
            }
            else if (readin == 1)
            {
                rest.Delete(idx, "album");

                Console.WriteLine("\n\n\n\n");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("[ALBUM DELETED SUCCESSFULLY]");
            }
            else if (readin == 2)
            {
                rest.Delete(idx, "song");

                Console.WriteLine("\n\n\n\n");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("[SONG DELETED SUCCESSFULLY]");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        #endregion

        #region NONCRUD

        private static void AVGLengthByAlbums(RestService rest)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[AVERAGE LENGTH BY ALBUMS IN DATABASE]");
            Console.WriteLine("\n\n");
            var result = rest.Get<KeyValuePair<string, double>>("stat/avglengthbyalbums");
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var item in result)
            {
                Console.WriteLine($"[ALBUM]: {item.Key} >>> [AVG LENGTH]: {item.Value}");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        private static void NumberOfExplSongsByArtists(RestService rest)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[NUMBER OF EXPLICIT SONGS BY ARTISTS IN DATABASE]");
            Console.WriteLine("\n\n");
            var result = rest.Get<KeyValuePair<string, int>>("stat/numberofexplicitsongsbyartists");
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (var item in result)
            {
                Console.WriteLine($"[ARTIST]: {item.Key} >>> [NO. OF EXPLICIT SONGS]: {item.Value}");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        private static void LengthOfAllSongsByCountries(RestService rest)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[LENGTH OF ALL SONGS BY COUNTRIES IN DATABASE]");
            Console.WriteLine("\n\n");
            var result = rest.Get<KeyValuePair<string, int>>("stat/lengthofallsongsbycountries");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            foreach (var item in result)
            {
                Console.WriteLine($"[COUNTRY]: {item.Key} >>> [LENGTH SUM]: {item.Value}");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        private static void NumberOfLoveSongsA2015ByArtists(RestService rest)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[NUMBER OF LOVE SONGS AFTER 2015 BY ARTISTS IN DATABASE]");
            Console.WriteLine("\n\n");
            var result = rest.Get<KeyValuePair<string, int>>("stat/numberoflovesongsafter2015byartists");
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var item in result)
            {
                Console.WriteLine($"[ARTIST]: {item.Key} >>> [NO. OF LOVE SONGS AFTER 2015]: {item.Value}");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        private static void NumberOfAlbumsRating8ByCountries(RestService rest)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[NUMBER OF ALBUMS WITH BIGGER RATING THAN 8 BY COUNTRIES]");
            Console.WriteLine("\n\n");
            var result = rest.Get<KeyValuePair<string, int>>("stat/numberofalbumswbiggerratingthan8bycountries");
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var item in result)
            {
                Console.WriteLine($"[COUNTRY]: {item.Key} >>> [NO. OF ALBUMS]: {item.Value}");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        #endregion
    }
}
