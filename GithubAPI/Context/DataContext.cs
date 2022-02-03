using GithubAPI.Entities;
using GithubAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GithubAPI.Context
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
             options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
            //options.UseInMemoryDatabase("TestDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here
  
            //Property Configurations
            modelBuilder.Entity<User>()
                                    .HasMany(x => x.Pulls).WithOne(x => x.User)
                                        .HasForeignKey(x => x.UserId)
                                        .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Pull>()
                         .HasOne(x => x.User).WithMany(x=> x.Pulls)
                            .HasForeignKey(x => x.UserId)
                            .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Pull>()
                         .HasMany(x => x.Reviews).WithOne(x => x.Pull)
                            .HasForeignKey(x => x.PullId)
                            .IsRequired(false)
                            .OnDelete(DeleteBehavior.ClientNoAction);


        }

        public DbSet<Repository> Repository { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Pull> Pull { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<User> User { get; set; }



    }
}
