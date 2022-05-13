using HANTruyen.Models.Configurations;
using HANTruyen.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HANTruyen.Models.EF
{
    public interface IEntity
    {
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
    }
    public class HANTruyenDbContext:DbContext
    {
        public HANTruyenDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoryConfiguration());
        }

        public DbSet<Story> Stories { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var now = DateTime.UtcNow;
            foreach(var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is IEntity entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.CreatedAt = now;
                            entity.CreatedBy = "AnhNH";
                            break;
                        case EntityState.Modified:
                            entity.UpdatedAt = now;
                            entity.UpdatedBy = "AnhNH";
                            break;
                    }
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
