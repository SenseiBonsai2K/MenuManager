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

        public async Task<DishType> GetByType(string type)
        {
            return await _context.DishTypes.FirstOrDefaultAsync(t => t.Type == type);
        }

        public async Task<bool> TypeExistsByName(string name)
        {
            return await _context.DishTypes.AnyAsync(t => t.Type == name);
        }

        public async Task AddDishType(DishType dishType)
        {
            await _context.DishTypes.AddAsync(dishType);
        }
    }
}
