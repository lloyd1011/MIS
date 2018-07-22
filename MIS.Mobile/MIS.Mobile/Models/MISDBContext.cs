using Microsoft.EntityFrameworkCore;
using MIS.Mobile.Helpers;
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
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = DependencyService.Get<IFileHelper>().GetPath();
            optionsBuilder.UseSqlite("FileName" + path);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
