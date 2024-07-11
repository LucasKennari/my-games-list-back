using my_games_list_back.Data;

namespace my_games_list_back.Features.Users
{
    public class CreateUserRequestHandler
    {
        private readonly MyGameListContext _context;

        public CreateUserRequestHandler(MyGameListContext context)
        {
            _context = context;
        }

    }
}
