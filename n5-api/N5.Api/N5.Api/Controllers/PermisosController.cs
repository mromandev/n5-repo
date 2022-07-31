using Microsoft.AspNetCore.Mvc;
using N5.Api.Entity.DTO;
using N5.Api.Interfaces.Service;
using N5.Api.Utils;

namespace N5.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermisosController : ControllerBase
    {
        private readonly IPermissionsService _permissionsService;

        public PermisosController(IPermissionsService permissionsService)
        {
            _permissionsService=permissionsService;
        }

        [HttpGet]
        public async Task<ActionResult> GetPermissions([FromRoute]int? permissionId = null)
        {
            try
            {
                if (permissionId is not null)
                {
                    PermissionDTO? permiso = await _permissionsService.Get((int)permissionId);

                    if (permiso is null)
                        return NotFound();
                    else
                        return Ok(permiso);
                }
                else
                {
                    return Ok(_permissionsService.GetAll());
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ha ocurrido un error inesperado.");
            }
        }

        [HttpPut]
        public async Task<ActionResult> ModifyPermission(PermissionDTO permission)
        {
            try
            {
                permission.FechaPermiso = DateTime.Now;
                return Ok(await _permissionsService.Update(permission.ToModel()));
            }
            catch (Exception ex)
            {
                throw new Exception($"Ha ocurrido un error inesperado.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> RequestPermission(PermissionDTO permission)
        {
            try
            {
                permission.FechaPermiso = DateTime.Now;
                return Ok(await _permissionsService.Add(permission.ToModel()));
            }
            catch (Exception ex)
            {
                throw new Exception($"Ha ocurrido un error inesperado.");
            }
        }
    }
}