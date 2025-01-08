using MenuManager.DTOs;
using MenuManager.Models.Context;
using MenuManager.Models.Entities;
using MenuManager.Models.Repositories;
using MenuManager.Requests;
using MenuManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MenuManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly DishServices dishServices;
        private readonly DishTypeServices dishTypeServices;

        public DishController(DishServices dishServices, DishTypeServices dishTypeServices)
        {
            this.dishServices = dishServices;
            this.dishTypeServices = dishTypeServices;
        }

        // GET: api/Dish/GetAll
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<DishDTO>>> GetAllDishes()
        {
            var dishes = new List<DishDTO>();
            try
            {
                foreach (var dish in await dishServices.GetAllDishes())
                {
                    dishes.Add(new DishDTO(dish));
                }
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            return Ok(dishes);
        }

        // POST: api/Dish/AddDish
        [HttpPost("AddDish")]
        public async Task<ActionResult> AddDish([FromBody] DishAddRequest dishAddRequest)
        {
            var dish = dishAddRequest.ToEntity();
            try
            {
                await dishServices.AddDish(dish);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            return Ok(dish.Name + "Added");
        }

        // DELETE: api/Dish/DeleteDish
        [HttpDelete("DeleteDish")]
        public async Task<ActionResult> DeleteDish(int id)
        {
            try
            {
                await dishServices.DeleteDish(id);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Dish Deleted");
        }
    }
}
