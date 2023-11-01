using Entities.Configuration;
using Entities.Models;
using Entities1._2.Configuration;
using Entities1._2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Entities
{
        public class RepositoryContext : IdentityDbContext<User>
        {
            public RepositoryContext(DbContextOptions options) : base(options)
            {

            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.ApplyConfiguration(new CompanyConfiguration());
                modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
                modelBuilder.ApplyConfiguration(new AyditoryaConfiguration());
                modelBuilder.ApplyConfiguration(new StudentConfiguration());
                modelBuilder.ApplyConfiguration(new RoleConfiguration());
            }

            public DbSet<Company> Companies { get; set; }
            public DbSet<Employee> Employees { get; set; }
            public DbSet<Ayditorya> Ayditoryas { get; set; }
            public DbSet<Student> Students { get; set; }


        }

}
