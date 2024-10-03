using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Movimientos
    {
        [Key]
        public int IdMovimiento { get; set; }
        public int IdUsuario { get; set; }
        public int IdCuentaOrigen { get; set; }
        public int IdCuentaDestino { get; set; }
        public decimal Movimiento { get; set; }
    }
}
