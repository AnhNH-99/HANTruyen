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
    public class HANTruyenDbContext : DbContext
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
            var AddedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();
            AddedEntities.ForEach(E =>
            {
                E.Property("CreatedAt").CurrentValue = now;
                E.Property("CreatedBy").CurrentValue = "AnhNH";
            });
            var EditedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();
            EditedEntities.ForEach(E =>
            {
                E.Property("UpdatedAt").CurrentValue = now;
                E.Property("UpdatedBy").CurrentValue = "AnhNH";
            });
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
