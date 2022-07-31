using N5.Api.Entity.DTO;
using N5.Api.Entity.Models;
using N5.Api.Interfaces.Repository;
using N5.Api.Interfaces.Service;
using N5.Api.Utils;

namespace N5.Api.Services
{
    public class PermissionsService : IPermissionsService
    {
        private readonly IPermissionsRepository _permisosRepository;
        private readonly IPermissionsTypesRepository _tiposPermisosRepository;

        public PermissionsService(IPermissionsRepository permisosRepository, IPermissionsTypesRepository tiposPermisosRepository)
        {
            this._permisosRepository=permisosRepository;
            this._tiposPermisosRepository=tiposPermisosRepository;
        }

        public async Task<PermissionDTO?> Get(int id)
        {
            try
            {
                Permission? permiso = await _permisosRepository.Get(id);
                return permiso?.ToDTO();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PermissionDTO> GetAll()
        {
            try
            {
                IEnumerable<Permission> permisos = _permisosRepository.GetAll();
                return permisos.Select(x => x.ToDTO()).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PermissionDTO> Add(Permission permiso)
        {
            try
            {
                VerificarIdTipoPermiso(permiso.IdTipoPermiso);
                permiso = await _permisosRepository.Add(permiso);
                return permiso.ToDTO();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PermissionDTO> Update(Permission permiso)
        {
            try
            {
                VerificarIdTipoPermiso(permiso.IdTipoPermiso);
                permiso = await _permisosRepository.Update(permiso);
                return permiso.ToDTO();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void VerificarIdTipoPermiso(int id)
        {
            if (!_tiposPermisosRepository.Exists(id))
                throw new ArgumentException($"No existe el tipo de permiso con ID {id}");
        }
    }
}