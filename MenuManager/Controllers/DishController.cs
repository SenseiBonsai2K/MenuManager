using MenuManager.DTOs;
using MenuManager.Models.Context;
using MenuManager.Models.Entities;
using MenuManager.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MenuManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly DishRepository _context;

        public DishController(DishRepository context)
        {
            _context = context;
        }

        // GET: api/Dish
        [HttpGet]
        public async Task<ActionResult<List<DishDTO>>> GetDishes()
        {
            var dishes = new List<DishDTO>();
            foreach (var dish in await _context.GetAllAsync())
            {
                dishes.Add(new DishDTO(dish));
            }
            return Ok(dishes);
        }
    }
}
