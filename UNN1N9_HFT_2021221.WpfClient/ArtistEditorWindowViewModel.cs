using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UNN1N9_HFT_2021221.Models;

namespace UNN1N9_HFT_2021221.WpfClient
{
    public class ArtistEditorWindowViewModel : ObservableRecipient
    {
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public RestCollection<Artist> Artists { get; set; }

        private Artist selectedArtist;

        public Artist SelectedArtist
        {
            get { return selectedArtist; }
            set
            {
                if (value != null)
                {
                    selectedArtist = new Artist()
                    {
                        ArtistName = value.ArtistName,
                        ArtistID = value.ArtistID,
                        CountryOfOrigin = value.CountryOfOrigin,
                        NumberOfAlbums = value.NumberOfAlbums
                    };
                    OnPropertyChanged();
                    (DeleteArtistCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateArtistCommand { get; set; }
        public ICommand DeleteArtistCommand { get; set; }
        public ICommand UpdateArtistCommand { get; set; }
        public ArtistEditorWindowViewModel()
        {

            if (!IsInDesignMode)
            {
                Artists = new RestCollection<Artist>("http://localhost:35739/", "artist", "hub");

                CreateArtistCommand = new RelayCommand(() =>
                {
                    Artists.Add(new Artist()
                    {
                        ArtistName = SelectedArtist.ArtistName,
                        CountryOfOrigin = SelectedArtist.CountryOfOrigin,
                        NumberOfAlbums = SelectedArtist.NumberOfAlbums
                    });
                });

                UpdateArtistCommand = new RelayCommand(() =>
                {
                    Artists.Update(SelectedArtist);
                });

                DeleteArtistCommand = new RelayCommand(() =>
                {
                    Artists.Delete(SelectedArtist.ArtistID);
                },
                () =>
                {
                    return SelectedArtist != null;
                });

                SelectedArtist = new Artist();
            }
        }
    }
}
