namespace MenuManager.Requests
{
    public class DishTypeUpdateRequest
    {
        public int DishTypeId { get; set; }
        public DishTypeAddRequest dishTypeAddRequest { get; set; }
    }
}
