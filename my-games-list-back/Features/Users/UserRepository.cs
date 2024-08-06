﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_games_list_back.Data;
using my_games_list_back.Helpers.PasswordHash;
using my_games_list_back.Repository;
using my_games_list_back.Repository.Interfaces;
using System.Collections.Immutable;

namespace my_games_list_back.Features.Users
{
    public class UserRepository : BaseRepository<UserEntity>
    {
        private readonly MyGameListContext _context;

        private readonly IPasswordHash _passwordHash;

        public UserRepository(MyGameListContext context, IPasswordHash passwordHash) : base(context)
        {
            _context = context;
            _passwordHash = passwordHash;
        }

        public async override Task<UserEntity> AddAsync(UserEntity entity)
        {
            await entity.IsValid(_context);
            var passwordHash = _passwordHash.Hash(entity.Password);
            entity.SetPassword(passwordHash);

            await base.AddAsync(entity);
            return entity;
        }

        public async override Task<IQueryable<UserEntity>> GetAllAsync()
        {
            return _context.Users.Where(e => e.IsActive);
            
          
        }
        public async Task<bool> UpdateAsync(UserRequest request)
        {
            var userEntity = await _context.Users.FindAsync(request.Id);
            if (userEntity == null)
            {
                return false;
            }            
            userEntity.Update(request);
            base.Update(request);
            return true;
        }
    }
}
