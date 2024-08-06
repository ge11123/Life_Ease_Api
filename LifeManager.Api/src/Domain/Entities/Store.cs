namespace LifeManage.src.Domain.Entities
{
	public class Store
	{
		public int StoreId { get; set; }
		public string Name { get; set; } = null!;
		public string? Address { get; set; }
		public decimal? Latitude { get; set; }
		public decimal? Longitude { get; set; }
		public int RegionId { get; set; }
	}
}
