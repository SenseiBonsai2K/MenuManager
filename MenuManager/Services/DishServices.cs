using MenuManager.Models.Entities;
using MenuManager.Models.Repositories;

namespace MenuManager.Services
{
    public class DishServices
    {
        public readonly DishRepository dishRepository;
        public readonly DishTypeRepository dishTypeRepository;

        public DishServices(DishRepository dishRepository, DishTypeRepository dishTypeRepository)
        {
            this.dishRepository = dishRepository;
            this.dishTypeRepository = dishTypeRepository;
        }

        public async Task<IEnumerable<Dish>> GetAllDishes()
        {
            return await dishRepository.GetAll();
        }

        public async Task AddDish(Dish dish)
        {
            var existingDishes = await dishRepository.GetDishesByName(dish.Name);
            if (existingDishes.Any())
            {
                throw new InvalidOperationException("A Dish with the same name already exists.");
            }
            dishRepository.AddDish(dish);
            await dishRepository.SaveChanges();
        }

        public async Task DeleteDish(int id)
        {
            var dish = await dishRepository.GetById(id);
            dishRepository.Delete(dish);
            await dishRepository.SaveChanges();
        }
    }
}
