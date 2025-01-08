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
    public class DishTypeRepository : GeneralRepository<DishType> {

        public DishTypeRepository(MyDbContext _context) : base(_context) { }

        public async Task<bool> TypeExistsByName(string type)
        {
            return await _context.DishTypes.AnyAsync(t => t.Type == type);
        }

        public async Task AddDishType(DishType dishType)
        {
            await _context.DishTypes.AddAsync(dishType);
        }

        public async Task UpdateDishType(DishType dishType)
        {
            _context.DishTypes.Update(dishType);
        }
    }
}
