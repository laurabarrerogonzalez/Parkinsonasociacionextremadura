using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Reflection.Emit;
using Data;

namespace Data
{
    public class ServiceContext : DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { }

        public DbSet<UsersItems> UsersItems { get; set; }
        public DbSet<VolunteersItems> Volunteers { get; set; }
        public DbSet<MembersItems> Members { get; set; }
        public DbSet<WorkItems> Works { get; set; }
        public DbSet<ResourcesItems> Resources { get; set; }
        public DbSet<NewsItem> News { get; set; }
        public DbSet<Gallery1Item> Gallery1 { get; set; }
        public DbSet<Gallery2Item> Gallery2 { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UsersItems>(entity =>
            {
                entity.ToTable("Users");
            });
            builder.Entity<VolunteersItems>(entity =>
            {
                entity.ToTable("Volunteers");
            });
            builder.Entity<MembersItems>(entity =>
            {
                entity.ToTable("Members");
            });
            builder.Entity<WorkItems>(entity =>
            {
                entity.ToTable("Works");
            });
            builder.Entity<ResourcesItems>(entity =>
            {
                entity.ToTable("Resources");
            });
            builder.Entity<NewsItem>(entity =>
            {
                entity.ToTable("News");
            });

            builder.Entity<Gallery1Item>(entity =>
            {
                entity.ToTable("Gallery1");
            });
            builder.Entity<Gallery2Item>(entity =>
            {
                entity.ToTable("Gallery2");
            });
        }
    }
}
public class ServiceContextFactory : IDesignTimeDbContextFactory<ServiceContext>
{
    public ServiceContext CreateDbContext(string[] args)
    {
        var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", false, true);
        var config = builder.Build();
        var connectionString = config.GetConnectionString("ServiceContext");
        var optionsBuilder = new DbContextOptionsBuilder<ServiceContext>();
        optionsBuilder.UseSqlServer(config.GetConnectionString("ServiceContext"));

        return new ServiceContext(optionsBuilder.Options);
    }
}
