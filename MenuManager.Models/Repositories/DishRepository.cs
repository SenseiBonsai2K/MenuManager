using MenuManager.Models.Context;
using MenuManager.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuManager.Models.Repositories
{
    public class DishRepository : GeneralRepository<Dish>
    {
        public DishRepository(MyDbContext _context) : base(_context) { }

        public async Task<IEnumerable<Dish>> GetDishesByType(string type)
        {
            return await _context.Dishes.Where(d => d.Type.Type.ToLower() == type.ToLower()).ToListAsync();
        }

        public async Task<IEnumerable<Dish>> GetDishesByTypeId(int typeId)
        {
            return await _context.Dishes.Where(d => d.Type.Id == typeId).ToListAsync();
        }

        public async Task<IEnumerable<Dish>> GetDishesByName(string name)
        {
            return await _context.Dishes.Where(d => d.Name.ToLower() == name.ToLower()).ToListAsync();
        }

        public async Task AddDish(Dish dish)
        {
            await _context.Dishes.AddAsync(dish);
        }

        public async Task UpdateDish(Dish dish)
        {
            _context.Dishes.Update(dish);
        }
    }
}
