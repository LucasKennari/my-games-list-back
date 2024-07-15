using my_games_list_back.Data;
using System.Linq.Expressions;

namespace my_games_list_back.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        // Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);(Perguntar ao zé)
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        bool SaveChanges();
    }
}
