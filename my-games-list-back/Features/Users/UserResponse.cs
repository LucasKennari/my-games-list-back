
namespace my_games_list_back.Features.Users
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }


        public static implicit operator UserResponse(UserEntity user)
        {
            return new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                NickName = user.Nickname,
                BirthDay = user.Birthday,
                Email = user.Email,
                CreatedAt = user.CreatedAt

            };
        }

        public static implicit operator UserResponse(Task<IQueryable<UserEntity>> v)
        {
            throw new NotImplementedException();
        }
    }
}
