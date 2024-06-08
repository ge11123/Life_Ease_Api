using LifeManage.src.Application.Queries.MonthlyTasks;
using LifeManage.src.Domain.entities;

namespace LifeManage.src.Infrastructure.Repositories.Interfaces
{
	public interface IMonthlyTasksRepository : IGenericRepository<TodoList>
	{
		Task<List<GetMonthlyTasksResponse>> QueryMonthlyTasksAsync(DateTime startTime, DateTime dateTime);
	}
}
