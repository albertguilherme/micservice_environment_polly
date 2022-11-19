using auth_mic_service.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace auth_mic_service.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Token> Tokens { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Base &&
                            e.State is EntityState.Added or EntityState.Modified or EntityState.Deleted);

            foreach (var entityEntry in entries)
            {
                ((Base)entityEntry.Entity).LastUpdate = DateTime.Now;

                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        ((Base)entityEntry.Entity).CreatedAt = DateTime.Now;
                        ((Base)entityEntry.Entity).IsDeleted = false;
                        break;
                    case EntityState.Deleted:
                        entityEntry.State = EntityState.Modified;
                        ((Base)entityEntry.Entity).IsDeleted = true;
                        break;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Base>().HasQueryFilter(p => !p.IsDeleted);

            base.OnModelCreating(builder);
        }
    }
}
