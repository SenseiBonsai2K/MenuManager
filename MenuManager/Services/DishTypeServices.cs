using MenuManager.Models.Entities;
using MenuManager.Models.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MenuManager.Services
{
    public class DishTypeServices
    {
        //public readonly DishRepository dishRepository;
        public readonly DishTypeRepository dishTypeRepository;

        public DishTypeServices(DishTypeRepository dishTypeRepository)
        {
            //this.dishRepository = dishRepository;
            this.dishTypeRepository = dishTypeRepository;
        }

        public async Task<IEnumerable<DishType>> GetAllDishTypes()
        {
            return await dishTypeRepository.GetAll();
        }

        public async Task AddDishType(DishType dishType)
        {
            await dishTypeRepository.AddDishType(dishType);
            await dishTypeRepository.SaveChanges();
        }
    }
}
