using my_games_list_back.Data;

namespace my_games_list_back.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        bool SaveChanges();
    }
}
