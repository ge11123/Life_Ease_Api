namespace LifeManage.src.Domain.Entities
{
	public class Region
	{
		public int RegionId { get; set; }
		public string CountyName { get; set; } = null!;
		public string TownshipName { get; set; } = null!;
	}
}
