using System;

using DesktopContactsApp.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DesktopContactsApp.Data
{
    public class DesktopContactsAppDbContext : DbContext
    {
        private readonly bool seedDb = true;

        public DesktopContactsAppDbContext() { }

        public DesktopContactsAppDbContext(DbContextOptions<DesktopContactsAppDbContext> options, bool seedDb = true)
            : base(options)
        {
            this.seedDb = seedDb;
            this.Database.EnsureCreated();
        }

        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (this.seedDb)
            {
                builder.Entity<Contact>()
                    .HasData(new Contact()
                    {
                        Id = 1,
                        Name = "Denis",
                        Email = "vassdeniss@gmail.com",
                        PhoneNumber = "+359882703944",
                    },
                    new Contact()
                    {
                        Id = 2,
                        Name = "Andrej",
                        Email = "andrej03@gmail.com",
                        PhoneNumber = "+421233527657",
                    }
                );
            }

            base.OnModelCreating(builder);
        }
    }
}
