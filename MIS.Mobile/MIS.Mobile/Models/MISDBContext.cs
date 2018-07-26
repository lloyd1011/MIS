﻿using Microsoft.EntityFrameworkCore;
using MIS.Mobile.Helpers;
using MIS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MIS.Mobile.Models
{
    public class MISDBContext : DbContext
    {
        public MISDBContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = DependencyService.Get<IFileHelper>().GetPath();
            optionsBuilder.UseSqlite("FileName" + path + "/myDb.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
 