using Microsoft.EntityFrameworkCore;

namespace identity.Models.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        public virtual DbSet<Configurations> Configurations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");
            modelBuilder.Entity<Configurations>(entity =>
            {
                entity.Property(e => e.SendGridUser).IsUnicode(false);

                entity.Property(e => e.SendGridKey).IsUnicode(false);
            });
        }

    }
}