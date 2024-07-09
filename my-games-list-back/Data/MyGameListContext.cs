
using Microsoft.EntityFrameworkCore;
using my_games_list_back.Features.Users;
using System.Reflection;

namespace my_games_list_back.Data
{
    public class MyGameListContext : DbContext
    {
     
        public DbSet<UserEntity> Users { get; set; }

        public MyGameListContext(DbContextOptions<MyGameListContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica automaticamente todas as configurações de entidades definidas no assembly atual
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
       
    }
}
