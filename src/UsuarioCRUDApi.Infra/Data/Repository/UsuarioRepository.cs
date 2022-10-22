using UsuarioCRUDApi.Business.Models.Usuarios;
using UsuarioCRUDApi.Infra.Data.Context;

namespace UsuarioCRUDApi.Infra.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {
        }
    }
}
