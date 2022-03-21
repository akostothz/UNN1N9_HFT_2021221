﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNN1N9_HFT_2021221.Models;

namespace UNN1N9_HFT_2021221.WpfClient
{
    public class MainWindowViewModel
    {
        public RestCollection<Song> Songs { get; set; }

        public MainWindowViewModel()
        {
            Songs = new RestCollection<Song>("http://localhost:35739", "song");
        }
    }
}
