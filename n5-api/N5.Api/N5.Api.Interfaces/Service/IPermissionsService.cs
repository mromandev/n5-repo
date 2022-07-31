using N5.Api.Entity.DTO;
using N5.Api.Entity.Models;
using N5.Api.Interfaces.Global;

namespace N5.Api.Interfaces.Service
{
    public interface IPermissionsService : IService<PermissionDTO, Permission>
    {
        // Requerimientos especificos para permisos.
    }
}
