using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UNN1N9_HFT_2021221.Models;

namespace UNN1N9_HFT_2021221.WpfClient
{
    public class NonCrudWindowViewModel
    {
        public RestCollection<Song> Songs { get; set; }

        public RestCollection<Album> Albums { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public NonCrudWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Albums = new RestCollection<Album>("http://localhost:35739/", "album", "hub");
                Songs = new RestCollection<Song>("http://localhost:35739/", "song", "hub");
            }
        }
    }
}
