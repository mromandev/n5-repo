using N5.Api.Entity.DTO;
using N5.Api.Entity.Models;
using N5.Api.Interfaces.Global;

namespace N5.Api.Interfaces.Service
{
    public interface IPermissionsTypesService : IService<PermissionsTypesDTO,PermissionType>
    {
        // Requerimientos especificos para tipospermisos.
        bool Exists(int id);
    }
}
