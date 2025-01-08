using MenuManager.Models.Entities;

namespace MenuManager.Requests
{
    public class DishAddRequest
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int TypeId { get; set; }

        public Dish ToEntity()
        {
            return new Dish
            {
                Name = Name,
                Price = Price,
                TypeId = TypeId
            };
        }
    }
}
