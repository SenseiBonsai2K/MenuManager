using MenuManager.DTOs;
using MenuManager.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MenuManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishTypeController : Controller
    {
        private readonly DishTypeRepository _dishTypeContext;

        public DishTypeController(DishTypeRepository context)
        {
            _dishTypeContext = context;
        }

        // GET: api/DishType
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<DishTypeDTO>>> GetAllDishTypes()
        {
            var dishTypes = new List<DishTypeDTO>();
            foreach (var types in await _dishTypeContext.GetAll())
            {
                dishTypes.Add(new DishTypeDTO(types));
            }
            return Ok(dishTypes);
        }
    }
}
