using my_games_list_back.Data;
using my_games_list_back.Repository.Interfaces;
using System.Xml.Linq;

namespace my_games_list_back.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {

        private readonly MyGameListContext _context;
        public BaseRepository(MyGameListContext context)
        {
            _context = context;
        }

        public async virtual Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
        public virtual Task<IQueryable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public virtual Task<T> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
