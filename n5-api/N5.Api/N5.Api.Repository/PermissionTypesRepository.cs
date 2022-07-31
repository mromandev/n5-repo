using Microsoft.EntityFrameworkCore;
using N5.Api.Entity;
using N5.Api.Entity.Models;
using N5.Api.Interfaces.Repository;

namespace N5.Api.Repository
{
    public class PermissionTypesRepository : IPermissionsTypesRepository
    {
        public readonly N5DbContext _dbContext;

        public PermissionTypesRepository(N5DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Exists(int id)
        {
            try
            {
                return _dbContext.TiposPermisos.Where(x => x.Id == id).Any();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PermissionType?> Get(int id)
        {
            try
            {
                return await _dbContext.TiposPermisos.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<PermissionType> GetAll()
        {
            try
            {
                return _dbContext.TiposPermisos.AsEnumerable();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PermissionType> Add(PermissionType permiso)
        {
            try
            {
                await _dbContext.TiposPermisos.AddAsync(permiso);
                await _dbContext.SaveChangesAsync();
                return permiso;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PermissionType> Update(PermissionType permiso)
        {
            try
            {
                _dbContext.TiposPermisos.Update(permiso);
                await _dbContext.SaveChangesAsync();
                return permiso;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}