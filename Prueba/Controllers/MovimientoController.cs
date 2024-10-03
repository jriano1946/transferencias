namespace Practicas.Controllers
{
    using Domain.Interfaces;
    using Entities;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientos _movimientos;
        public MovimientoController(IMovimientos transferencia)
        {
            _movimientos = transferencia;
        }
        [HttpPost]
        public bool Insertar(Movimientos movimiento)
        {
            return _movimientos.Create(movimiento);
        }

        [HttpGet]
        public IEnumerable<Movimientos> Obtener()
        {
            return _movimientos.Get();
        }

        [HttpGet("ObtenerMovimientos")]
        public IEnumerable<Movimientos> ObtenerSaldo(int idUser)
        {
            return _movimientos.GetMovimientos(idUser);
        }
    }
}
