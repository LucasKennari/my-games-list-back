using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace my_games_list_back.Features.Users;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        // Definindo a chave primária
        builder.HasKey(u => u.Id);

        // Configurando a propriedade Username
        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.Nickname)
            .IsRequired()
            .HasMaxLength(255);

        // Configurando a propriedade Email
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        // Configurando a propriedade PasswordHash
        builder.Property(u => u.Password)
            .IsRequired();

        // Configurando a propriedade Birthday
        builder.Property(u => u.Birthday)
            .IsRequired();

        // Configurando a propriedade CreatedAt
        builder.Property(u => u.CreatedAt)
            .IsRequired();

        builder.Property(u => u.IsActive)
            .IsRequired();

        // Definindo índices
        builder.HasIndex(u => u.Email).IsUnique();
        builder.HasIndex(u => u.Nickname).IsUnique();
    }
}
