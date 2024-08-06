using Microsoft.EntityFrameworkCore.Diagnostics;

namespace LifeManage.src.Domain.Entities
{
	public class LedgerTransaction
	{
		public long TransactionId { get; set; }
		public int UserId { get; set; }
		public int CategoryId { get; set; }
		public decimal Amount { get; set; }
		public string? Note { get; set; } 
		public DateTime TransactionDate { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}

}
