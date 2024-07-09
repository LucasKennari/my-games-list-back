using Microsoft.EntityFrameworkCore;
using my_games_list_back.Data;
using my_games_list_back.Features.Users;
using my_games_list_back.Repository.Interfaces;

namespace my_games_list_back.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public readonly MyGameListContext _context;
        public UserRepository(MyGameListContext context) : base (context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> GetUsers()
        {
            var user = _context.Users.Include(x => x.Nickname).ToList();
            return user;
        }

        public UserEntity GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id.Equals(id));
           
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
