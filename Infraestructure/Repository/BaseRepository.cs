using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        protected readonly ClienteDbContext _clienteDbContext;
        protected readonly DbSet<TEntity> DbSet;


        public BaseRepository(ClienteDbContext context)
        {
            _clienteDbContext = context;
            DbSet = _clienteDbContext.Set<TEntity>();


        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _clienteDbContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public IUnitOfWork UnitOfWork => _clienteDbContext;

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(CreateAsync)} entity must not be null");
            }

            try
            {
                await _clienteDbContext.AddAsync(entity);
                await _clienteDbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }
        public async Task<TEntity> GetById(Guid id)
        {

            try
            {
                return await DbSet.FindAsync(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }

            try
            {
                _clienteDbContext.Update(entity);
                await _clienteDbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetById(id);
            _clienteDbContext.Set<TEntity>().Remove(entity);
            await _clienteDbContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _clienteDbContext.Dispose();
        }
    }
}
