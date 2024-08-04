namespace LifeManage.src.Domain.Entities
{
	public class LedgerCategory
	{
		public int CategoryId { get; set; }
		public int UserId { get; set; }
		public string Name { get; set; } = null!;
		public string Type { get; set; } = null!;
		public string Icon { get; set; } = null!;
	}

}
