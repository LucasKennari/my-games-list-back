using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_games_list_back.Data;
using my_games_list_back.Features.Users;

namespace my_games_list_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserRepository _repository;

        public UsersController(UserRepository repository)
        {
            _repository = repository;
        }

        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Product1", "Product2" };
        }

        // GET api/products/5
        [HttpGet(Name = "RogerinhoDoQuero")]
        public ActionResult<string> Get(int id)
        {
            return "Product" + id;
        }

        // POST api/products
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserRequest user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            UserEntity userEntity = user;
            try
            {
                _repository.Add(userEntity);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
