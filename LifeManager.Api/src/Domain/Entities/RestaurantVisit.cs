namespace LifeManage.src.Domain.Entities
{
    public class RestaurantVisit
    {
		public int Id { get; set; }
		public int RestaurantId { get; set; }
		public DateTime DateVisited { get; set; }
		public int UserId { get; set; }
	}
}
