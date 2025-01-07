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
    public class DishTypeRepository {

        public MyDbContext context;

        public DishTypeRepository(MyDbContext context)
        {
            this.context = context;
        }
        public async Task<DishType> GetByTypologyAsync(string type)
            {
                return await context.DishTypes.FirstOrDefaultAsync(t => t.Type == type);
            }

        public async Task<bool> ExistByNameAsync(string name)
        {
            return await context.DishTypes.AnyAsync(t => t.Type == name);
        }
    }
}
