﻿using my_games_list_back.Data;
using System.Linq.Expressions;

namespace my_games_list_back.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);

        public Task<T> AddAsync(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public Task LogicDeleteAsync(Guid id);
    }
}
