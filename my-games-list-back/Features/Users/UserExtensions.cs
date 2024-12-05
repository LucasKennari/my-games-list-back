using my_games_list_back.Data;

namespace my_games_list_back.Features.Users
{
    public static class UserExtensions
    {
        public async static Task<(bool isValid, string error)> IsValid(this UserEntity userEntity, MyGameListContext context)
        {
            UserValidator userValidator = new UserValidator(context);
            var result =  await userValidator.ValidateAsync(userEntity);
            var isValid = result.IsValid;
            var error = string.Empty;

            if (!isValid)
            {
                error = string.Join(",",result.Errors.Select(x => x.ErrorMessage));
                throw new ArgumentException(error);
            }
            return (isValid, error);
        }
    }
}
