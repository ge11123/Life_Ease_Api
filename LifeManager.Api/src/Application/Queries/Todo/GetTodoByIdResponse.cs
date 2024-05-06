namespace LifeManage.src.Application.Queries.Todo
{
	public record GetTodoByIdResponse
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
		public string? Description { get; set; }
		public bool IsCompleted { get; set; }
		public DateTime? DueTime { get; set; }
	}
}
