using MenuManager.DTOs;
using MenuManager.Models.Repositories;
using MenuManager.Requests;
using MenuManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace MenuManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishTypeController : Controller
    {
        private readonly DishServices dishServices;
        private readonly DishTypeServices dishTypeServices;

        public DishTypeController(DishServices dishServices, DishTypeServices dishTypeServices)
        {
            this.dishServices = dishServices;
            this.dishTypeServices = dishTypeServices;
        }

        // GET: api/DishType
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<DishTypeDTO>>> GetAllDishTypes()
        {
            var dishTypes = new List<DishTypeDTO>();
            foreach (var types in await dishTypeServices.GetAllDishTypes())
            {
                dishTypes.Add(new DishTypeDTO(types));
            }
            return Ok(dishTypes);
        }

        // POST: api/DishType/AddDishType
        [HttpPost("AddDishType")]
        public async Task<ActionResult> AddDishType([FromBody] DishTypeAddRequest dishTypeAddRequest)
        {
            var dishType = dishTypeAddRequest.ToEntity();
            try
            {
                await dishTypeServices.AddDishType(dishType);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            return Ok(dishType.Type + " Added");
        }

        // DELETE: api/DishType/DeleteDishType
        [HttpDelete("DeleteDishType")]
        public async Task<ActionResult> DeleteDishType(int id)
        {
            try
            {
                await dishTypeServices.DeleteDishType(id);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            return Ok("DishType Deleted");
        }
    }
}
