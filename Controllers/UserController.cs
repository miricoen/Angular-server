using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeServer.Model;

namespace RecipeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<User> users = new List<User> {
            new User{Id=1, Name="miri", Address="bney braq", Email="123@gmail.com", Password="1234" },
            new User{Id=2, Name="miri", Address="bney braq", Email="123@gmail.com", Password="1234" },
            new User{Id=3, Name="miri", Address="bney braq", Email="123@gmail.com", Password="1234" }
        };

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return users;
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user = users.Find((p) => p.Id == id);
            return user;
        }

        //הוספת משתמש חדש למערכת
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (users.Any(u => u.Name == user.Name && u.Password == user.Password))
            {
                return StatusCode(409, "User already exists");
            }

            users.Add(user);
            return Ok(user);
        }

        //קבלת ה ID של המשתמש ע"י שם וסיסמה
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var existingUser = users.FirstOrDefault(u => u.Name == user.Name && u.Password == user.Password);
            if (existingUser != null)
            {
                return Ok(existingUser.Id);
            }
            else
            {
                return NotFound("User not found");
            }
        }

    }
}
