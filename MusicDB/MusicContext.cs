using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MusicDB
{
    public partial class MusicContext : DbContext
    {
        public MusicContext()
            : base("name=MusicContext")
        {
        }

        public DbSet<Autor> Autors { get; set; }
        public DbSet<Song> Songs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
