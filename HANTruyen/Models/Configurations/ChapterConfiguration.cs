using HANTruyen.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANTruyen.Models.Configurations
{
    public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
    {
        public void Configure(EntityTypeBuilder<Chapter> builder)
        {
            builder.ToTable("CHAPTER");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(x => x.StroyId).HasColumnName("STORY_ID");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Title).HasColumnName("TITLE");
            builder.Property(x => x.Description).HasColumnName("DESCRIPTION");
            builder.Property(x => x.Status).HasColumnName("STATUS");
            builder.Property(x => x.Views).HasColumnName("VIEWS").HasDefaultValue(0);
            builder.Property(x => x.Likes).HasColumnName("LIKES").HasDefaultValue(0);
            builder.Property(x => x.CreatedAt).HasColumnName("CREATED_AT").HasColumnType("datetime");
            builder.Property(x => x.UpdatedAt).HasColumnName("UPDATED_AT").HasColumnType("datetime");
            builder.Property(x => x.CreatedBy).HasColumnName("CREATED_BY").HasMaxLength(256);
            builder.Property(x => x.UpdatedBy).HasColumnName("UPDATED_BY").HasMaxLength(256);
            builder.Property(x => x.DeletedFlag).HasColumnName("DELETED_FLAG").HasDefaultValue(false);
            builder.HasOne(x => x.Story).WithMany(y => y.Chapters).HasForeignKey(z => z.StroyId);
        }
    }
}
