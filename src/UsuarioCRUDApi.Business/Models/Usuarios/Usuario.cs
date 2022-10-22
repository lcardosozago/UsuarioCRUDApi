using UsuarioCRUDApi.Business.Core.Models;

namespace UsuarioCRUDApi.Business.Models.Usuarios
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Escolaridade { get; set; }
    }
}
