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

        public List<KeyValuePair<string, double>> AVGLengthByAlbum
        {
            get
            {
                return rest.Get<KeyValuePair<string, double>>("stat/avglengthbyalbums");
            }
            private set { OnPropertyChanged(); }
        }
        public List<KeyValuePair<string, int>> GreaterThan8Albums
        {
            get
            {
                return rest.Get<KeyValuePair<string, int>>("stat/numberofalbumswbiggerratingthan8bycountries");
            }
            private set { OnPropertyChanged(); }
        }
        public List<KeyValuePair<string, int>> ExplicitSongsByArtist
        {
            get
            {
                return rest.Get<KeyValuePair<string, int>>("stat/numberofexplicitsongsbyartists");
            }
            private set { OnPropertyChanged(); }
        }
        public List<KeyValuePair<string, int>> AllLengthByCountries
        {
            get
            {
                return rest.Get<KeyValuePair<string, int>>("stat/lengthofallsongsbycountries");
            }
            private set { OnPropertyChanged(); }
        }
        public List<KeyValuePair<string, int>> LovesongsAfter2015
        {
            get
            {
                return rest.Get<KeyValuePair<string, int>>("stat/numberoflovesongsafter2015byartists");
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
