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
    }
}
