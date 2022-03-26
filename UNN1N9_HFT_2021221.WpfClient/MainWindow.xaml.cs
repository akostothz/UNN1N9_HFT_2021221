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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UNN1N9_HFT_2021221.WpfClient
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ArtistButton_Click(object sender, RoutedEventArgs e)
        {
            ArtistEditorWindow arew = new ArtistEditorWindow();
            //arew.Show();
        }
        private void AlbumButton_Click(object sender, RoutedEventArgs e)
        {
            AlbumEditorWindow alew = new AlbumEditorWindow();
            //alew.Show();
        }
        private void SongButton_Click(object sender, RoutedEventArgs e)
        {
            SongEditorWindow sew = new SongEditorWindow();
            //sew.Show();
        }
    }
}
