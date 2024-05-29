using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Domain.Interfaces.Repository
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
