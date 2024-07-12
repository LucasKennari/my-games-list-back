using my_games_list_back.Data;
using my_games_list_back.Repository.Interfaces;

namespace my_games_list_back.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly MyGameListContext _context;
        public BaseRepository(MyGameListContext context)
        {
            _context = context; 
        }

        public virtual void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
