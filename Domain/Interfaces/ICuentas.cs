using Entities;

namespace Domain.Interfaces
{
    public interface ICuentas
    {
        bool Create(Cuentas cuenta);
        IEnumerable<Cuentas> Get();
        decimal GetBalanceByUser(int idUser);
        bool BloquearCuenta(int idUser);
    }
}
