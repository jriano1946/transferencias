using Domain.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Transferencias.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentasController : ControllerBase
    {
        private readonly ICuentas _cuentas;
        public CuentasController(ICuentas cuentas)
        {
            _cuentas = cuentas;
        }
        [HttpPost]
        public bool Insertar(Cuentas cuentas)
        {
            return _cuentas.Create(cuentas);
        }

        [HttpGet]
        public IEnumerable<Cuentas> Obtener()
        {
            return _cuentas.Get();
        }

        [HttpGet("ObtenerSaldo")]
        public decimal ObtenerSaldo(int idUser)
        {
            return _cuentas.GetBalanceByUser(idUser);
        }

        [HttpPatch("BloquearCuenta")]
        public bool BloquearCuenta(int idUser)
        {
            return _cuentas.BloquearCuenta(idUser);
        }
    }
}
