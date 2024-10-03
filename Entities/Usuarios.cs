using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
    }
}
