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
    public class AlbumEditorWindowViewModel : ObservableRecipient
    {
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public RestCollection<Album> Albums { get; set; }

        private Album selectedAlbum;

        public Album SelectedAlbum
        {
            get { return selectedAlbum; }
            set
            {
                if (value != null)
                {
                    selectedAlbum = new Album()
                    {
                        //deep copy
                        AlbumName = value.AlbumName,
                        AlbumID = value.AlbumID
                    };
                    OnPropertyChanged();
                    (DeleteAlbumCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateAlbumCommand { get; set; }
        public ICommand DeleteAlbumCommand { get; set; }
        public ICommand UpdateAlbumCommand { get; set; }
        public AlbumEditorWindowViewModel()
        {

            if (!IsInDesignMode)
            {
                Albums = new RestCollection<Album>("http://localhost:35739", "album", "hub");

                CreateAlbumCommand = new RelayCommand(() =>
                {
                    Albums.Add(new Album()
                    {
                        //deep copy
                        AlbumName = SelectedAlbum.AlbumName
                    });
                });

                UpdateAlbumCommand = new RelayCommand(() =>
                {
                    Albums.Update(SelectedAlbum);
                });

                DeleteAlbumCommand = new RelayCommand(() =>
                {
                    Albums.Delete(SelectedAlbum.AlbumID);
                },
                () =>
                {
                    return SelectedAlbum != null;
                });

                SelectedAlbum = new Album();
            }
        }
    }
}
