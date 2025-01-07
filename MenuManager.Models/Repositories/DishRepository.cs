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
    public class DishRepository 
    {
        public MyDbContext context;

        public DishRepository(MyDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Dish>> GetByTypologyAsync(string type)
        {
            return await context.Dishes.Where(d => d.Type.Type.ToLower() == type.ToLower()).ToListAsync();
        }

        public async Task<IEnumerable<Dish>> GetByTypologyIdAsync(int typeId)
        {
            return await context.Dishes.Where(d => d.Type.Id == typeId).ToListAsync();
        }

        public async Task<IEnumerable<Dish>> GetWithPriceGreatherThanAsync(double price)
        {
            return await context.Dishes.Where(d => d.Price > price)
                .OrderBy(d => d.Price)
                .ToListAsync();
        }

        public async Task<IEnumerable<Dish>> GetWithPriceLessThanAsync(double price)
        {
            return await context.Dishes.Where(d => d.Price < price)
                .OrderBy(d => d.Price)
                .ToListAsync();
        }

        public async Task<IEnumerable<Dish>> GetByName(string name)
        {
            return await context.Dishes.Where(d => d.Name.ToLower() == name.ToLower()).ToListAsync();
        }

    }
}
