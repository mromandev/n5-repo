using N5.Api.Entity.DTO;
using N5.Api.Entity.Models;

namespace N5.Api.Utils
{
    public static class ModelExtension
    {
        public static Permission ToModel(this PermissionDTO e)
        {
            return new Permission
            {
                Id = e.Id,
                NombreEmpleado = e.NombreEmpleado,
                ApellidoEmpleado = e.ApellidoEmpleado,
                IdTipoPermiso = e.IdTipoPermiso,
                FechaPermiso = e.FechaPermiso
            };
        }

        public static PermissionDTO ToDTO(this Permission e)
        {
            if (e == null) return null;

            return new PermissionDTO
            {
                Id = e.Id,
                NombreEmpleado = e.NombreEmpleado,
                ApellidoEmpleado = e.ApellidoEmpleado,
                IdTipoPermiso = e.IdTipoPermiso,
                FechaPermiso = e.FechaPermiso
            };
        }

        public static PermissionType ToModel(this PermissionsTypesDTO e)
        {
            return new PermissionType
            {
                Id = e.Id,
                Descripcion = e.Descripcion
            };
        }

        public static PermissionsTypesDTO ToDTO(this PermissionType e)
        {
            return new PermissionsTypesDTO
            {
                Id = e.Id,
                Descripcion = e.Descripcion
            };
        }
    }
}