namespace LifeManage.src.Domain.entities
{
	public class TodoList
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
		public string? Description { get; set; }
		public bool IsDone { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }
	}

}
