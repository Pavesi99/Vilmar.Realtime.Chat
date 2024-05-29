using System.Linq.Expressions;

namespace Vilmar.Realtime.Chat.Areas.Generic
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public  IEnumerable<TEntity> Get(
           Expression<Func<TEntity, bool>>? filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
           string includeProperties = "",
            short limit = 0, short page = 0);

        public Task Add(TEntity entity);
        public   Task<IEnumerable<TEntity>> GetAllAsync();

        public TEntity GetByID(object id);

        public  Task InsertAsync(TEntity entity);


        public  void Delete(object id);

        public  void Delete(TEntity entityToDelete);

        public  void Update(TEntity entityToUpdate);
    }
}
