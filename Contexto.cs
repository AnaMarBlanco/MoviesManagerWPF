using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesManagerWPF
{
    class Contexto : DbContext
    {
        public DbSet<Peliculas> Peliculas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= Database.db;");
        }
    }
}
