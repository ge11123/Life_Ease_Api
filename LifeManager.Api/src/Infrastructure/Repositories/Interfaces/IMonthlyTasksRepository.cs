using LifeManage.src.Application.Queries.MonthlyTasks;
using LifeManage.src.Domain.entities;
using System.Linq.Expressions;

namespace LifeManage.src.Infrastructure.Repositories.Interfaces
{
	public interface IMonthlyTasksRepository : IGenericRepository<TodoList>
	{
		Task<List<GetMonthlyTasksResponse>> QueryMonthlyTasksAsync(Expression<Func<TodoList, bool>> predicate);
	}
}
