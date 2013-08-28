using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GammaRaySetlist.Model;

namespace GammaRaySetList.Data
{
    public class GammaRayContext : DbContext
    {
        static GammaRayContext()
        {
            Database.SetInitializer(new GammaRayDatabaseInitializer());
        }
        public GammaRayContext()
            : base(nameOrConnectionString: "GammaRay") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new BandConfiguration());
            modelBuilder.Configurations.Add(new SongConfiguration());
        }

        public DbSet<Band> Bands { get; set; }
        public DbSet<Song> Songs { get; set; }

    }
}
