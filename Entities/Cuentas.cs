namespace Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Cuentas
    {
        [Key]
        public int IdCuenta { get; set; }
        public int IdUsuario { get; set; }
        public decimal Saldo { get; set; }
        public bool Estado { get; set; }
    }
}
