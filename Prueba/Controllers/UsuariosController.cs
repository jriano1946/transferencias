using Data;
using Domain.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace Transferencias.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarios _usuarios;
        public UsuariosController(IUsuarios usuarios)
        {
            _usuarios = usuarios;
        }

        [HttpPost]
        public bool Insertar(Usuarios usuario)
        {
            return _usuarios.Create(usuario);
        }

        [HttpGet]
        public IEnumerable<Usuarios> Get()
        {
            return _usuarios.Get();
        }

    }
}
