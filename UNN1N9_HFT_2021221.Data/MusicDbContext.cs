﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNN1N9_HFT_2021221.Data
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext()
        {
            this.Database.EnsureCreated();
        }
    }
}