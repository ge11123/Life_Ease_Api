namespace LifeManage.src.Domain.Entities
{
	public class LedgerUser
	{
		public int UserId { get; set; }
		public string UserName { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string AuthToken { get; set; } = null!;
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}

}
