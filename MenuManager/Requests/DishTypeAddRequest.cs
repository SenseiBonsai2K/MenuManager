using MenuManager.Models.Entities;

namespace MenuManager.Requests
{
    public class DishTypeAddRequest
    {
        public string Type { get; set; }

        public DishType ToEntity() 
        {
            return new DishType
            {
                Type = Type
            };
        }
    }
}
