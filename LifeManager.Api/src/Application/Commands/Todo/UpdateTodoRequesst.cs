namespace LifeManage.src.Application.Commands.Todo
{
	public class UpdateTodoRequest
	{
		public bool? IsCompleted { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
	}
}
