using MenuManager.Models.Entities;

namespace MenuManager.DTOs
{
    public class DishDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }

        public DishDTO(Dish dish)
        {
            this.Id = dish.Id;
            this.Name = dish.Name;
            this.Price = dish.Price;
            this.Type = dish.Type.Type;
        }
    } 
}
