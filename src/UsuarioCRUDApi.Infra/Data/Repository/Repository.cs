using Microsoft.EntityFrameworkCore;
using UsuarioCRUDApi.Business.Core.Data;
using UsuarioCRUDApi.Business.Core.Models;
using UsuarioCRUDApi.Infra.Data.Context;

namespace UsuarioCRUDApi.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly AppDbContext _context;

        protected Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TEntity>> ObterTodos()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> ObterPorId(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task Criar(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Editar(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public virtual async Task Excluir(int id)
        {
            _context.Entry(new TEntity{Id = id}).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
