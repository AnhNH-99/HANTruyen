using HANTruyen.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HANTruyen.Models.Configurations
{
    public class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.ToTable("CONTENT");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(256);
            builder.Property(x => x.ChapterId).HasColumnName("CHAPTER_ID");
            builder.Property(x => x.BaseImage).HasColumnName("BASE_IMAGE").HasColumnType("text").IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("CREATED_AT").HasColumnType("datetime");
            builder.Property(x => x.UpdatedAt).HasColumnName("UPDATED_AT").HasColumnType("datetime");
            builder.Property(x => x.CreatedBy).HasColumnName("CREATED_BY").HasMaxLength(256);
            builder.Property(x => x.UpdatedBy).HasColumnName("UPDATED_BY").HasMaxLength(256);
            builder.Property(x => x.DeletedFlag).HasColumnName("DELETED_FLAG").HasDefaultValue(false);
            builder.HasOne(x => x.Chapter).WithMany(y => y.Contents).HasForeignKey(z => z.ChapterId);
        }
    }
}
