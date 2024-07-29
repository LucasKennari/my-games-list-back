namespace my_games_list_back.Helpers.PasswordHash
{
    public interface IPasswordHash
    {
        string Hash(string password);
        bool ValidateHash(string password, string hash);
    }
}
