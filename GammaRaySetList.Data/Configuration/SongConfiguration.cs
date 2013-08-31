using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using GammaRaySetlist.Model;

namespace GammaRaySetList.Data
{
    public class SongConfiguration : EntityTypeConfiguration<Song>
    {
        public SongConfiguration()
        {
            this.HasKey(q => q.Id);

            this.Property(q => q.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(q => q.Name).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            this.Property(q => q.Listened).IsOptional();

            this.ToTable("Song");
        }
    }
}
