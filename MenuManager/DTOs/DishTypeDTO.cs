using MenuManager.Models.Entities;

namespace MenuManager.DTOs
{
    public class DishTypeDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public DishTypeDTO(DishType dishType)
        {
            Id = dishType.Id;
            Type = dishType.Type;
        }
    }
}
