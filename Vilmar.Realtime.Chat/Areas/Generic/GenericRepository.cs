using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Vilmar.Realtime.Chat.Areas.Context;

namespace Vilmar.Realtime.Chat.Areas.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal ApplicationDbContext context;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
            this._dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "", short limit = 0, short page = 0)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (limit > 0 && page > 0)
            {
                if (page == 1)
                    query = query.Take(limit);
                else
                    query = query.Skip(limit*(page-1));
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }


        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            context.SaveChanges();
        }

        public virtual TEntity GetByID(object id)
        {
            return _dbSet.Find(id) ?? throw new ApplicationException($"Não foi possível encontrar o item de id:{id} no banco de dados");
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }


        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id) ?? throw new ApplicationException($"Não foi possível encontrar o item de id:{id} no banco de dados");
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.Update(entityToUpdate);
        }
    }

}
