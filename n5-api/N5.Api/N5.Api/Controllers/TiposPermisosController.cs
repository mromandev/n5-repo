using Microsoft.AspNetCore.Mvc;
using N5.Api.Entity.DTO;
using N5.Api.Interfaces.Service;

namespace N5.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiposPermisosController : ControllerBase
    {
        private readonly IPermissionsTypesService _permissionsTypesService;

        public TiposPermisosController(IPermissionsTypesService permissionTypesService)
        {
            _permissionsTypesService=permissionTypesService;
        }

        [HttpGet]
        public async Task<ActionResult> GetPermissionTypes(int? permissionTypeId = null)
        {
            try
            {
                if (permissionTypeId != null)
                {
                    PermissionsTypesDTO? permiso = await _permissionsTypesService.Get((int)permissionTypeId);

                    if (permiso == null)
                        return NotFound();
                    else
                        return Ok(permiso);
                }
                else
                {
                    return Ok(_permissionsTypesService.GetAll());
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ha ocurrido un error inesperado.");
            }
        }
    }
}