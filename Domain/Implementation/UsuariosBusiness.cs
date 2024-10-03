using Domain.Interfaces;
using Entities;
using Repository;

namespace Domain.Implementation
{
    public class UsuariosBusiness : IUsuarios
    {
        private IUnitOfWork _unit;

        public UsuariosBusiness(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public bool Create(Usuarios usuarios)
        {
            try
            {
                _unit.GenericRepository<Usuarios>().Insert(usuarios);
                _unit.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Usuarios> Get()
        {
            return _unit.GenericRepository<Usuarios>().Get();
        }
    }
}
