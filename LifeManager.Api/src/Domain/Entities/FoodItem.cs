namespace LifeManage.src.Domain.Entities
{
	public class FoodItem
	{
		public int FoodItemId { get; set; }
		public int VisitId { get; set; }
		public string FoodName { get; set; } = null!;
		public int FoodCategoryId { get; set; }
		public int Cost { get; set; }
	}
}
