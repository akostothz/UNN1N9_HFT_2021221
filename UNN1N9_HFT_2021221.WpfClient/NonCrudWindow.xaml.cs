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
            var result = rest.Get<KeyValuePair<string, int>>("stat/numberofalbumswbiggerratingthan8bycountries");
            List<string> greaterthan8 = new List<string>();
            foreach (var item in result)
            {
                greaterthan8.Add(item.Key + ": " + item.Value);
            }

        }
    }
}
