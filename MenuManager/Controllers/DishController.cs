using MenuManager.Models.Context;
using MenuManager.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MenuManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly MyDbContext _context;

        public DishController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Dish
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dish>>> GetDishes()
        {
            var c = _context.Dishes.ToListAsync().Result;
            return c;
        }
    }
}
