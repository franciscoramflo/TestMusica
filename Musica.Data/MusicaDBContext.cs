using Microsoft.EntityFrameworkCore;

using Musica.Data.Entities;

using System;

namespace Musica.Data
{
    public class MusicaDBContext : DbContext
    {
        //Constructor sin parametros
        public MusicaDBContext()
        {
        }

        //Constructor con parametros para la configuracion
        public MusicaDBContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Musica;Persist Security Info=True;User ID=sa;Password=nectri;MultipleActiveResultSets=True");
            }
        }

        //Tablas de datos
        #region Tables

        public virtual DbSet<Song> Songs { get; set; }


        #endregion
    }
}
