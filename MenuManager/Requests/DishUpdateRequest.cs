using MenuManager.Models.Entities;

namespace MenuManager.Requests
{
    public class DishUpdateRequest
    {
        public int DishId { get; set; }
        public DishAddRequest DishAddRequest { get; set; }
    }
}
