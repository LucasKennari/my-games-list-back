using my_games_list_back.Data;

namespace my_games_list_back.Features.Users
{
    public static class UserExtensions
    {   
        public static (bool isValid, string error) IsValid(this UserEntity userEntity, MyGameListContext context)
        {
            UserValidator userValidator = new UserValidator(context);
            var result = userValidator.Validate(userEntity);
            var isValid = result.IsValid;
            var error = result.ToString();

            if (!isValid)
                throw new ArgumentException(error);

            return (isValid, error);
        }
    }
}
