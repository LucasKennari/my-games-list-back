using Microsoft.EntityFrameworkCore;
using my_games_list_back.Features.Users;
using System.Reflection;

namespace my_games_list_back.Data
{
    public class MyGameListContext : DbContext
    {
       //as informacoes que contem o GetConnections na classe program vao ser passadas pra ca
       // e esse construtor vai passar essas informacoes para a classe pai que é o DbContext.
       // a  palavra BASE serve justamente para isso.
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
        //esse DbSet é uma tabela que contem os user, todos os DbSet recebem os nomes das tabelas
        //recebem a entidade que vai se transformar em tabela, ela serve justamente para ajudar a migration
        //DbSet<UserEntity> Users { get; set; }
    }
}
