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
    public class MainWindowViewModel : ObservableRecipient
    {
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public RestCollection<Song> Songs { get; set; }

        private Song selectedSong;

        public Song SelectedSong
        {
            get { return selectedSong; }
            set 
            {
                selectedSong = new Song()
                {
                    SongName = value.SongName,
                    SongID = value.SongID,
                    Style = value.Style,
                    Length = value.Length,
                    IsExplicit = value.IsExplicit,
                    IsLoveSong = value.IsLoveSong
                };
                OnPropertyChanged();
                (DeleteSongCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }


        public ICommand CreateSongCommand { get; set; }
        public ICommand DeleteSongCommand { get; set; }
        public ICommand UpdateSongCommand { get; set; }
        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Songs = new RestCollection<Song>("http://localhost:35739", "song");

                CreateSongCommand = new RelayCommand(() =>
                {
                    Songs.Add(new Song()
                    {
                        SongName = "Softcore"
                    });
                });

                UpdateSongCommand = new RelayCommand(() =>
                {

                });

                DeleteSongCommand = new RelayCommand(() =>
                {
                    Songs.Delete(SelectedSong.SongID);
                },
                () =>
                {
                    return SelectedSong != null;
                });
            }          
        }
    }
}
