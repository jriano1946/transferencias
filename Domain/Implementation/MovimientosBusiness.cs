namespace Domain.Implementation
{
    using Domain.Interfaces;
    using Entities;
    using Repository;
    using System.Collections.Generic;

    public class MovimientosBusiness : IMovimientos
    {
        private IUnitOfWork _unit;
        public MovimientosBusiness(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public bool Create(Movimientos movimiento)
        {
            try
            {
                _unit.GenericRepository<Movimientos>().Insert(movimiento);
                var cuentaOrigen = _unit.GenericRepository<Cuentas>().Get(x => x.IdCuenta == movimiento.IdCuentaOrigen)?.FirstOrDefault();
                var cuentaDestino = _unit.GenericRepository<Cuentas>().Get(x => x.IdCuenta == movimiento.IdCuentaDestino)?.FirstOrDefault();

                cuentaOrigen.Saldo = cuentaOrigen.Saldo - movimiento.Movimiento;
                cuentaDestino.Saldo = cuentaDestino.Saldo + movimiento.Movimiento;

                _unit.GenericRepository<Cuentas>().Update(cuentaOrigen);
                _unit.GenericRepository<Cuentas>().Update(cuentaDestino);
                _unit.Save();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Movimientos> Get()
        {
            return _unit.GenericRepository<Movimientos>().Get();
        }

        public IEnumerable<Movimientos> GetMovimientos(int idUser)
        {
            return _unit.GenericRepository<Movimientos>().Get(x=> x.IdUsuario == idUser);
        }
    }
}
