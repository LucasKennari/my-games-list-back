﻿using my_games_list_back.Data;

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

        public static implicit operator UserEntity(UserRequest user)
        {
            return new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = user.Name,
                Nickname = user.NickName,
                Birthday = user.BirthDay,
                Email = user.Email,
                Password = user.Password,
                IsActive = true
            };
        }

        public void Update(UserRequest request)
        {
            Name = request.Name;
            Nickname = request.NickName;
            Birthday = request.BirthDay;
            Email = request.Email;
            IsActive = request.IsActive;
        }

        public void SetPassword(string password)
        {
            Password = password;
        }
    }
}
