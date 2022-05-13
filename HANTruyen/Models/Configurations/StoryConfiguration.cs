using HANTruyen.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANTruyen.Models.Configurations
{
    public class StoryConfiguration : IEntityTypeConfiguration<Story>
    {
        public void Configure(EntityTypeBuilder<Story> builder)
        {
            builder.ToTable("STORY");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("NAME").IsRequired();
            builder.Property(x => x.Title).HasColumnName("TITLE");
            builder.Property(x => x.Description).HasColumnName("DESCRIPTION").HasColumnType("text");
            builder.Property(x => x.Status).HasColumnName("STATUS").HasDefaultValue(0);
            builder.Property(x => x.Author).HasColumnName("AUTHOR").IsRequired();
            builder.Property(x => x.Views).HasColumnName("VIEWS").HasDefaultValue(0);
            builder.Property(x => x.Follows).HasColumnName("FOLLOWS").HasDefaultValue(0);
            builder.Property(x => x.Likes).HasColumnName("LIKES").HasDefaultValue(0);
            builder.Property(x => x.CreatedAt).HasColumnName("CREATED_AT").HasColumnType("datetime").HasDefaultValueSql("GetUtcDate()");
            builder.Property(x => x.UpdatedAt).HasColumnName("UPDATED_AT").HasColumnType("datetime").HasDefaultValueSql("GetUtcDate()");
            builder.Property(x => x.CreatedBy).HasColumnName("CREATED_BY").HasMaxLength(256);
            builder.Property(x => x.UpdatedBy).HasColumnName("UPDATED_BY").HasMaxLength(256);
            builder.Property(x => x.DeletedFlag).HasColumnName("DELETED_FLAG").HasDefaultValue(false);
        }
    }
}
