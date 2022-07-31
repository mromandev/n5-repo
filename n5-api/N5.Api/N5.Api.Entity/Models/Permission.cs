using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N5.Api.Entity.Models
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(70)]
        public string NombreEmpleado { get; set; }

        [Required]
        [MaxLength(70)]
        public string ApellidoEmpleado { get; set; }

        [Required]
        public DateTime FechaPermiso { get; set; }

        [Required]
        [ForeignKey("TiposPermisos")]
        public int IdTipoPermiso { get; set; }
        
        public virtual PermissionType TiposPermisos { get; set; }
    }
}