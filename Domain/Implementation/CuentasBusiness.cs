using Domain.Interfaces;
using Entities;
using Repository;

namespace Domain.Implementation
{
    public class CuentasBusiness : ICuentas
    {
        private IUnitOfWork _unit;
        public CuentasBusiness(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public bool BloquearCuenta(int idUser)
        {
            try
            {
                var cuenta = _unit.GenericRepository<Cuentas>().Get(x => x.IdUsuario == idUser)?.FirstOrDefault();
                if (cuenta != null)
                {
                    cuenta.Estado = false;
                    _unit.GenericRepository<Cuentas>().Update(cuenta);
                    _unit.Save();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Create(Cuentas cuenta)
        {
            try
            {
                _unit.GenericRepository<Cuentas>().Insert(cuenta);
                _unit.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Cuentas> Get()
        {
            return _unit.GenericRepository<Cuentas>().Get();
        }

        public decimal GetBalanceByUser(int idUser)
        {
            var saldo = _unit.GenericRepository<Cuentas>().Get(x => x.IdUsuario == idUser);
            if (saldo.Any())
            {
                return saldo.FirstOrDefault().Saldo;
            }
            return 0;
        }
    }
}
