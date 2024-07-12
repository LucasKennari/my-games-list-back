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
            IsValid();
        }

        public (bool isValid, string error) IsValid()
        {
            UserValidator userValidator = new UserValidator();
            var result = userValidator.Validate(this);
            var isValid = result.IsValid;
            var error = result.ToString();

            if (!isValid)            
                throw new Exception(error);
            
            return (isValid, error);
        }

        public static implicit operator UserEntity(UserResponse user)
        {
            return new UserEntity
            {
                Name = user.Name,
                Nickname = user.NickName,
                Birthday = user.BirthDay,
                Email = user.Email,
                // Password 
            };
        }

        public void SetPassword(string password)
        {
            Password = password;
        }
    }
}
