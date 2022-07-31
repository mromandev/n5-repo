using System.ComponentModel.DataAnnotations;

namespace N5.Api.Entity.Models
{
    public class PermissionType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; }
    }
}