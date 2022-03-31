using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UNN1N9_HFT_2021221.Models;

namespace UNN1N9_HFT_2021221.WpfClient
{
    /// <summary>
    /// Interaction logic for NonCrudWindow.xaml
    /// </summary>
    public partial class NonCrudWindow : Window
    {
        public NonCrudWindow()
        {
            InitializeComponent();
            RestService rest = new RestService("http://localhost:35739/");
            Setup(rest);

        }
        public void Setup(RestService rest)
        {
            GreaterThan8NC(rest);
            AvgLength(rest);
            ExplicitPerArtist(rest);
            AllSongLengthByCountries(rest);
            LoveSongsAfter2015(rest);
        }
        public void GreaterThan8NC(RestService rest)
        {
            var result = rest.Get<KeyValuePair<string, int>>("stat/numberofalbumswbiggerratingthan8bycountries");
            List<string> greaterthan8 = new List<string>();
            foreach (var item in result)
            {
                greaterthan8.Add(item.Key + ":   " + item.Value);
            }
            for (int i = 0; i < greaterthan8.Count; i++)
            {
                lbox1.Items.Add(new Label());
            }
            for (int i = 0; i < lbox1.Items.Count; i++)
            {
                (lbox1.Items[i] as Label).Content = greaterthan8.ElementAt(i);
                (lbox1.Items[i] as Label).Foreground = Brushes.CornflowerBlue;
                (lbox1.Items[i] as Label).FontSize = 10;
            }
        }

        public void AvgLength(RestService rest)
        {
            var result = rest.Get<KeyValuePair<string, double>>("stat/avglengthbyalbums");
            List<string> lengths = new List<string>();
            foreach (var item in result)
            {
                lengths.Add(item.Key + ":   " + Math.Round(item.Value, 2));
            }
            for (int i = 0; i < lengths.Count; i++)
            {
                lbox2.Items.Add(new Label());
            }
            for (int i = 0; i < lbox2.Items.Count; i++)
            {
                (lbox2.Items[i] as Label).Content = lengths.ElementAt(i);
                (lbox2.Items[i] as Label).Foreground = Brushes.DarkSeaGreen;
                (lbox2.Items[i] as Label).FontSize = 10;
            }
        }

        public void ExplicitPerArtist(RestService rest)
        {
            var result = rest.Get<KeyValuePair<string, int>>("stat/numberofexplicitsongsbyartists");
            List<string> explicitsongs = new List<string>();
            foreach (var item in result)
            {
                explicitsongs.Add(item.Key + ":   " + item.Value);
            }
            for (int i = 0; i < explicitsongs.Count; i++)
            {
                lbox3.Items.Add(new Label());
            }
            for (int i = 0; i < lbox3.Items.Count; i++)
            {
                (lbox3.Items[i] as Label).Content = explicitsongs.ElementAt(i);
                (lbox3.Items[i] as Label).Foreground = Brushes.MediumVioletRed;
                (lbox3.Items[i] as Label).FontSize = 10;
            }
        }

        public void AllSongLengthByCountries(RestService rest)
        {
            var result = rest.Get<KeyValuePair<string, int>>("stat/lengthofallsongsbycountries");
            List<string> alllength = new List<string>();
            foreach (var item in result)
            {
                alllength.Add(item.Key + ":   " + item.Value);
            }
            for (int i = 0; i < alllength.Count; i++)
            {
                lbox4.Items.Add(new Label());
            }
            for (int i = 0; i < lbox4.Items.Count; i++)
            {
                (lbox4.Items[i] as Label).Content = alllength.ElementAt(i);
                (lbox4.Items[i] as Label).Foreground = Brushes.DarkOrange;
                (lbox4.Items[i] as Label).FontSize = 10;
            }
        }

        public void LoveSongsAfter2015(RestService rest)
        {
            var result = rest.Get<KeyValuePair<string, int>>("stat/numberoflovesongsafter2015byartists");
            List<string> lovesongs = new List<string>();
            foreach (var item in result)
            {
                lovesongs.Add(item.Key + ":   " + item.Value);
            }
            for (int i = 0; i < lovesongs.Count; i++)
            {
                lbox5.Items.Add(new Label());
            }
            for (int i = 0; i < lbox5.Items.Count; i++)
            {
                (lbox5.Items[i] as Label).Content = lovesongs.ElementAt(i);
                (lbox5.Items[i] as Label).Foreground = Brushes.Purple;
                (lbox5.Items[i] as Label).FontSize = 10;
            }
        }
    }
}
