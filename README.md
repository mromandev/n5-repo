# N5 SSr .NET Test -  Marcelo Roman

## Notas

Formulario realizado con la última versión de React.

API en .NET 6 con EntityFramework code first.

## Problemas conocidos
- No se ha aplicado la conexión a ElasticSearch solicitado.
- Al momento de realizar la migración del dbContext interfiere la inyeccion de IConfiguration. Se omite comentando la inyeccion dentro del dbContext durante la migración.

```
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using N5.Api.Entity.Models;

namespace N5.Api.Entity
{
    public class N5DbContext : DbContext
    {
        //protected readonly IConfiguration Configuration;

        //public N5DbContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //var connectionString = Configuration.GetConnectionString("n5database");
            options.UseSqlServer("Server=localhost;Database=n5database;Trusted_Connection=True;");
        }

        public DbSet<Permission> Permisos { get; set; }
        public DbSet<PermissionType> TiposPermisos { get; set; }
    }
}
```
