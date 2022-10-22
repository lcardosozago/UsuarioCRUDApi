using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioCRUDApi.Business.Core.Models;

namespace UsuarioCRUDApi.Business.Core.Data
{
    public interface IRepository<TEntity>
    {
        Task<List<TEntity>> ObterTodos();
        Task<TEntity> ObterPorId(int id);
        Task Criar(TEntity entity);
        Task Editar(TEntity entity);
        Task Excluir(int id);
    }
}
