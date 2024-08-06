using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_games_list_back.Data;
using my_games_list_back.Features.Users;
using my_games_list_back.Repository.Interfaces;
using System.Linq.Expressions;

namespace my_games_list_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IBaseRepository<UserEntity> _userRepository;
        public UsersController(IBaseRepository<UserEntity> userRepository)
        {

            _userRepository = userRepository;
        }

        // GET api/users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetAllAsync();

            List<UserResponse> userListResponse = users.Select(u => (UserResponse)u).ToList();
            try
            {
                if (users == null)
                {
                    return NotFound("Users not found");
                }

                return Ok(userListResponse);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET api/user/{Guid}
        [HttpGet("{Guid}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            try
            {
                if (user == null)
                {
                    return NotFound("User not found");
                }

                UserResponse userResponse = user;
                return Ok(userResponse);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }


        // POST api/users
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserRequest? user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("Usuario nulo");
                }
                UserEntity userEntity = user;
                await _userRepository.AddAsync(userEntity);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/users/{Guid}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                await _userRepository.LogicDeleteAsync(id);

            }
            catch (ArgumentException ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
