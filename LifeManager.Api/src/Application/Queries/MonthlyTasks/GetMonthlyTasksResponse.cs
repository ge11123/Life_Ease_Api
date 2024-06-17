namespace LifeManage.src.Application.Queries.MonthlyTasks
{
	public class GetMonthlyTasksResponse
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;
		public string? Description { get; set; }
		public bool IsCompleted { get; set; }
		public string? DueDate { get; set; }
	}
}
