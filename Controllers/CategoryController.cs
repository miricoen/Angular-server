using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeServer.Model;

namespace RecipeServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public static List<Category> categories = new List<Category>{
            new Category{ Id=1, Name= "Cakes", Url="https://cdn-icons-png.freepik.com/512/5717/5717439.png"},
            new Category{ Id=2, Name="Cookies", Url="https://as2.ftcdn.net/v2/jpg/01/42/59/37/1000_F_142593716_DwD3p6AGPR8A2f9jEc1xYA6wp7y6OdcR.jpg"},
            new Category{ Id=3, Name = "Choclates", Url="https://macademic.co.il/wp-content/uploads/2018/12/petifurim_1.jpg"}
            };

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return categories;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

    }
}
