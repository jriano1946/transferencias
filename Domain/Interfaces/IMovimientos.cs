namespace Domain.Interfaces
{
    using Entities;

    public interface IMovimientos
    {
        bool Create(Movimientos movimiento);
        IEnumerable<Movimientos> Get();
        IEnumerable<Movimientos> GetMovimientos(int idUser);
    }
}
