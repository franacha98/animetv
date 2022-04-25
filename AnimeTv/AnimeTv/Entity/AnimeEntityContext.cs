using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeTv.Entity
{
    public class AnimeEntityContext : DbContext
    {
        public AnimeEntityContext(DbContextOptions<AnimeEntityContext> pOptions) : base(pOptions)
        {

        }

        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Video>(e => e.Property(o => o.Capitulo).HasConversion<short>());
            //modelBuilder.Entity<Video>(e => e.Property(o => o.Temporada).HasConversion<short>());
        }
    }
}
