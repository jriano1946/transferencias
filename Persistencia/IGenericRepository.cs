namespace Repository
{
    using System.Linq.Expressions;
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(
             Expression<Func<TEntity, bool>> filter = null,
             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
             string includeProperties = "");
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
    }
}
