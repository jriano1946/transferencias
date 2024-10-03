using Entities;

namespace Domain.Interfaces
{
    public interface IUsuarios
    {
        bool Create(Usuarios ciudad);

        IEnumerable<Usuarios> Get();
    }
}
