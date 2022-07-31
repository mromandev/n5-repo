using N5.Api.Entity.DTO;
using N5.Api.Entity.Models;
using N5.Api.Interfaces.Repository;
using N5.Api.Interfaces.Service;
using N5.Api.Utils;

namespace N5.Api.Services
{
    public class PermissionTypesService : IPermissionsTypesService
    {
        private readonly IPermissionsTypesRepository _tiposPermisosRepository;

        public PermissionTypesService(IPermissionsTypesRepository tiposPermisosRepository)
        {
            this._tiposPermisosRepository=tiposPermisosRepository;
        }

        public bool Exists(int id)
        {
            try
            {
                return _tiposPermisosRepository.Exists(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PermissionsTypesDTO?> Get(int id)
        {
            try
            {
                PermissionType? tipoPermiso = await _tiposPermisosRepository.Get(id);
                return tipoPermiso?.ToDTO();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PermissionsTypesDTO> GetAll()
        {
            try
            {
                IEnumerable<PermissionType> listaTipos = _tiposPermisosRepository.GetAll();
                return listaTipos.Select(x => x.ToDTO()).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PermissionsTypesDTO> Add(PermissionType tipoPermiso)
        {
            try
            {
                tipoPermiso = await _tiposPermisosRepository.Add(tipoPermiso);
                return tipoPermiso.ToDTO();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<PermissionsTypesDTO> Update(PermissionType tipoPermiso)
        {
            try
            {
                tipoPermiso = await _tiposPermisosRepository.Update(tipoPermiso);
                return tipoPermiso.ToDTO();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}