using DesktopContactsApp.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace DesktopContactsApp.Data
{
    public class DesktopContactsAppDbContext : DbContext
    {
        public DesktopContactsAppDbContext() { }

        public DesktopContactsAppDbContext(DbContextOptions<DesktopContactsAppDbContext> options)
            : base(options) { }

        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
