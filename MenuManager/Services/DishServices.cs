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
            dishRepository.AddDish(dish);
            await dishRepository.SaveChanges();
        }
    }
}
