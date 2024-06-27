using my_games_list_back.Data;

namespace my_games_list_back.Features.Users
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; private set; }
        public string Nickname { get; private set; }
        public DateTime Birthday { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        private UserEntity() { }

        public UserEntity(string name, string nickname, DateTime birthday, string email, string password)
        {
            Name = name;
            Nickname = nickname;
            Birthday = birthday;
            Email = email;
            Password = password;
        }
    }
}
