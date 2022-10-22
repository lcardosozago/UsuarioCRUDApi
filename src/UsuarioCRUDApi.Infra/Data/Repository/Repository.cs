using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using UsuarioCRUDApi.Business.Core.Data;
using UsuarioCRUDApi.Business.Core.Models;
using UsuarioCRUDApi.Infra.Data.Context;

namespace UsuarioCRUDApi.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
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

        public async Task Criar(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Editar(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            if (entity == null) return;

            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
