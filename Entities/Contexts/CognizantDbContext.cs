using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Contexts
{
    public class CognizantDbContext : DbContext
    {
        public CognizantDbContext(DbContextOptions<CognizantDbContext> options, IConfiguration configuration)
                                                                                : base(options)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Let's also implement the general version.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="configuration"></param>
        protected CognizantDbContext(DbContextOptions options, IConfiguration configuration)
                                                                        : base(options)
        {
            Configuration = configuration;
        }

        protected IConfiguration Configuration { get; set; }

        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<WareHouse> WareHouses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.Entity<Location>(entity => { entity.ToTable("Location"); });
            //modelBuilder.Entity<Vehicle>(entity => { entity.ToTable("Vehicle"); });
            //modelBuilder.Entity<Cars>(entity => { entity.ToTable("Cars"); });
            //modelBuilder.Entity<WareHouse>(entity => { entity.ToTable("WareHouse"); });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Context")).EnableSensitiveDataLogging());

            }
        }
    }
}
