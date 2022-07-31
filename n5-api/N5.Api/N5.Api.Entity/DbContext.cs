using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using N5.Api.Entity.Models;

namespace N5.Api.Entity
{
    public class N5DbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public N5DbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("n5database");
            options.UseSqlServer(connectionString);
        }

        public DbSet<Permission> Permisos { get; set; }
        public DbSet<PermissionType> TiposPermisos { get; set; }
    }
}
