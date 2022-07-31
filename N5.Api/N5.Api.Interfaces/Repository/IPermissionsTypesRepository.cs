using N5.Api.Entity.Models;
using N5.Api.Interfaces.Global;

namespace N5.Api.Interfaces.Repository
{
    public interface IPermissionsTypesRepository : IRepository<PermissionType>
    {
        // Futuras definiciones de tipospermisosrepository
        bool Exists(int id);
    }
}
