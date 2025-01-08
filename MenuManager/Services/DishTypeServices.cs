using MenuManager.Models.Entities;
using MenuManager.Models.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

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

        public async Task AddDishType(DishType dishType)
        {
            if(await dishTypeRepository.TypeExistsByName(dishType.Type)) 
            { 
                throw new InvalidOperationException("A DishType with the same type already exists."); 
            }
            await dishTypeRepository.AddDishType(dishType);
            await dishTypeRepository.SaveChanges();
        }

        public async Task DeleteDishType(int id)
        {
            var dishes = await dishRepository.GetDishesByTypeId(id);
            var dishType = await dishTypeRepository.GetById(id);
            if(dishes.Any())
            {
                throw new InvalidOperationException("DishType is in use");
            }
            dishTypeRepository.Delete(dishType);
            await dishTypeRepository.SaveChanges();
        }

    }
}
