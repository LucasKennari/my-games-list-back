﻿using my_games_list_back.Data;
using my_games_list_back.Helpers.PasswordHash;
using my_games_list_back.Repository;
using my_games_list_back.Repository.Interfaces;

namespace my_games_list_back.Features.Users
{
    public class UserRepository: BaseRepository<UserEntity>
    {
        private readonly MyGameListContext _context;
        
        private readonly IPasswordHash _passwordHash;
        
        public UserRepository(MyGameListContext context, IPasswordHash passwordHash) : base(context)
        {
            _context = context;
            _passwordHash = passwordHash;
        }
        
        public override void Add(UserEntity entity)
        {
            var passwordHash = _passwordHash.Hash(entity.Password);
            entity.SetPassword(passwordHash);

            base.Add(entity);
        }
    }
}
