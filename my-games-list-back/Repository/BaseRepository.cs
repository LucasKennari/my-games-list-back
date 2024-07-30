using Microsoft.EntityFrameworkCore;
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

        public async virtual Task LogicDeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            entity.SetIsActive(false);
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

        /// <summary>
        ///     Tries to get an ID from the database
        /// </summary>
        /// <param name="id">
        ///     Id of an entity
        /// </param>
        /// <returns>
        ///     Entity
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     Throws an argument exception if the provided Id was not found on the database.
        /// </exception>
        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(x=>x.Id==id);
            if (entity == null)
                throw new ArgumentException($"Id:{id} was not found.");   
            return entity;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
