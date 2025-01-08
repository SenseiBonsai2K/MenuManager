using MenuManager.Models.Entities;
using MenuManager.Models.Repositories;

namespace MenuManager.Services
{
    public class DishTypeServices
    {
        public readonly DishRepository dishRepository;
        public readonly DishTypeRepository dishTypeRepository;

        public DishTypeServices(DishRepository dishRepository, DishTypeRepository dishTypeRepository)
        {
            this.dishRepository = dishRepository;
            this.dishTypeRepository = dishTypeRepository;
        }

        public async Task<IEnumerable<DishType>> GetAllDishTypes()
        {
            return await dishTypeRepository.GetAll();
        }
    }
}
