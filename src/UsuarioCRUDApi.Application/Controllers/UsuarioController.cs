using Microsoft.AspNetCore.Mvc;
using UsuarioCRUDApi.Business.Models.Usuarios;

namespace UsuarioCRUDApi.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(
            ILogger<UsuarioController> logger,
            IUsuarioRepository usuarioRepository
        )
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Usuario>> Get()
        {
            return await _usuarioRepository.ObterTodos();
        }

        [HttpGet("{id:int}")]
        public async Task<Usuario> GetById(int id)
        {
            var usuario = await _usuarioRepository.ObterPorId(id);

            return usuario;
        }

        [HttpPost]
        public async Task Post([FromBody] Usuario usuario)
        {
            await _usuarioRepository.Criar(usuario);
        }

        [HttpPut]
        public async Task Put([FromBody] Usuario usuario)
        {
            await _usuarioRepository.Editar(usuario);
        }

        [HttpDelete("{id:int}")]
        public async Task Delete(int id)
        {
            await _usuarioRepository.Excluir(id);
        }
    }
}