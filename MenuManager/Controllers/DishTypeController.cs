using MenuManager.DTOs;
using MenuManager.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MenuManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishTypeController : Controller
    {
        private readonly DishTypeRepository _context;

        public DishTypeController(DishTypeRepository context)
        {
            _context = context;
        }

        // GET: api/Dish
        [HttpGet]
        public async Task<ActionResult<List<DishTypeDTO>>> GetDishes()
        {
            var dishTypes = new List<DishTypeDTO>();
            foreach (var types in await _context.GetAllAsync())
            {
                dishTypes.Add(new DishTypeDTO(types));
            }
            return Ok(dishTypes);
        }
    }
}
