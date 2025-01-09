using MenuManager.Models.Entities;
using MenuManager.Models.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

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

        public async Task<DishType> GetDishTypeById(int id)
        {
            var dishType = await dishTypeRepository.GetById(id);
            if (dishType == null)
            {
                throw new InvalidOperationException("Dish type not found");
            }
            return dishType;
        }

        public async Task AddDishToTipologyAsync(int dishTypeId, int dishId)
        {
            var dishType = await GetDishTypeById(dishTypeId);
            var dish = await dishRepository.GetById(dishId);
            dishType.Dishes.Add(dish);
            await dishTypeRepository.SaveChanges();
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

        public async Task UpdateDishType(int Id, DishType dishType)
        {
            var dishTypeToUpdate = await dishTypeRepository.GetById(Id);
            if (await dishTypeRepository.TypeExistsByName(dishType.Type))
            {
                throw new InvalidOperationException("A DishType with the same type already exists.");
            }
            dishTypeToUpdate.Type = dishType.Type;
            await dishTypeRepository.UpdateDishType(dishTypeToUpdate);
            await dishTypeRepository.SaveChanges();
        }

    }
}
