namespace N5.Api.Entity.DTO
{
    public class PermissionDTO
    {
        public int Id { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public int IdTipoPermiso { get; set; }
        public DateTime FechaPermiso { get; set; }
    }
}