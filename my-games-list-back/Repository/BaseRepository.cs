using my_games_list_back.Data;
using my_games_list_back.Repository.Interfaces;

namespace my_games_list_back.Repository
{
    public class BaseRepository : IBaseRepository
    {
        public readonly MyGameListContext _context;
        public BaseRepository(MyGameListContext context)
        {
            _context = context; 
        }
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
