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

        public async virtual void Add(T entity)
        {           
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();       
        }

        public async void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public bool SaveChanges()
        {
           return _context.SaveChanges();
        }

        public async void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
