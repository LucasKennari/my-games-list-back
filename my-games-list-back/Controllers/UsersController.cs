using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_games_list_back.Data;
using my_games_list_back.Features.Users;
using my_games_list_back.Repository.Interfaces;

namespace my_games_list_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _repository;
        private readonly IBaseRepository<UserEntity> _userRepository;
        public UsersController(IBaseRepository<UserEntity> userRepository)
        {
            //repository = repository;
            _userRepository = userRepository;
        }
        /*
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Product1", "Product2" };
        }
       */

        // GET api/users
        [HttpGet]
        public ActionResult<string> Get(Guid id)
        {
            return "Product" + id;
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

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                await _userRepository.LogicDeleteAsync(id);

            }
            catch (ArgumentException ex)
            {

                return BadRequest("Usuario nulo");
            }
            return Ok();
        }
    }
}
