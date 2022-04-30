using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UNN1N9_HFT_2021221.Models;

namespace UNN1N9_HFT_2021221.WpfClient
{
    public class NCWindowViewModel : ObservableRecipient
    {
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        RestService rest;
        public RestCollection<Album> Albums { get; set; }
        public RestCollection<Artist> Artists { get; set; }
        public RestCollection<Song> Songs { get; set; }

        public List<string> AVGLengthByAlbum
        {
            get
            {
                var res = rest.Get<KeyValuePair<string, double>>("stat/avglengthbyalbums");
                List<string> w = new List<string>();
                res.ForEach(x => w.Add($"{x.Key}:  {Math.Round(x.Value)}"));
                return w;
            }
            private set { OnPropertyChanged(); }
        }
        public List<string> GreaterThan8Albums
        {
            get
            {
                var res = rest.Get<KeyValuePair<string, int>>("stat/numberofalbumswbiggerratingthan8bycountries");
                List<string> w = new List<string>();
                res.ForEach(x => w.Add($"{x.Key}:  {x.Value}"));
                return w;
            }
            private set { OnPropertyChanged(); }
        }
        public List<string> ExplicitSongsByArtist
        {
            get
            {
                var res = rest.Get<KeyValuePair<string, int>>("stat/numberofexplicitsongsbyartists");
                List<string> w = new List<string>();
                res.ForEach(x => w.Add($"{x.Key}:  {x.Value}"));
                return w;
            }
            private set { OnPropertyChanged(); }
        }
        public List<string> AllLengthByCountries
        {
            get
            {
                var res = rest.Get<KeyValuePair<string, int>>("stat/lengthofallsongsbycountries");
                List<string> w = new List<string>();
                res.ForEach(x => w.Add($"{x.Key}:  {x.Value}"));
                return w;
            }
            private set { OnPropertyChanged(); }
        }
        public List<string> LovesongsAfter2015
        {
            get
            {
                var res = rest.Get<KeyValuePair<string, int>>("stat/numberoflovesongsafter2015byartists");
                List<string> w = new List<string>();
                res.ForEach(x => w.Add($"{x.Key}:  {x.Value}"));
                return w;
            }
            private set { OnPropertyChanged(); }
        }

        public NCWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                rest = new RestService("http://localhost:35739/");
                Albums = new RestCollection<Album>("http://localhost:35739/", "album", "hub");
                Artists = new RestCollection<Artist>("http://localhost:35739/", "artist", "hub");
                Songs = new RestCollection<Song>("http://localhost:35739/", "song", "hub");
            }
        }
    }
}
