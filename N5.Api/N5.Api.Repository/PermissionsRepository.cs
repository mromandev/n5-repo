using Microsoft.EntityFrameworkCore;
using N5.Api.Entity;
using N5.Api.Entity.Models;
using N5.Api.Interfaces.Repository;

namespace N5.Api.Repository
{
    public class PermissionsRepository : IPermissionsRepository
    {
        public readonly N5DbContext _dbContext;

        public PermissionsRepository(N5DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Permission?> Get(int id)
        {
            try
            {
                return await _dbContext.Permisos.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Permission> GetAll()
        {
            try
            {
                return _dbContext.Permisos.AsEnumerable();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Permission> Add(Permission permiso)
        {
            try
            {
                await _dbContext.Permisos.AddAsync(permiso);
                await _dbContext.SaveChangesAsync();
                return permiso;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Permission> Update(Permission permiso)
        {
            try
            {
                _dbContext.Permisos.Update(permiso);
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