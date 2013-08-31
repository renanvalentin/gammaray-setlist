using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using GammaRaySetlist.Model;

namespace GammaRaySetList.Data
{
    public class BandConfiguration : EntityTypeConfiguration<Band>
    {
        public BandConfiguration()
        {
            this.HasKey(q => q.Id);

            this.Property(q => q.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(q => q.Name).HasColumnType("varchar").HasMaxLength(30).IsRequired();

            this.HasMany(q => q.Songs)
                .WithRequired(q => q.Band)
                .Map(q => q.MapKey("BandID"));

            this.ToTable("Band");
        }
    }
}
