using my_games_list_back.Features.Users;

namespace my_games_list_back.Repository.Interfaces
{
    public interface IUserRepository : IBaseRepository
    {
        IEnumerable<UserEntity> GetUsers();

        UserEntity GetUserById(int id);
    }
}
