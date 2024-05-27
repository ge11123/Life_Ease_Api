using LifeManage.src.Application.Handlers.Interface;
using LifeManage.src.Application.Queries.Interface;
using LifeManage.src.Application.Queries.MonthlyTasks;
using LifeManage.src.Infrastructure.Repositories.Interfaces;

namespace LifeManage.src.Application.Handlers.MonthlyTasks
{
	public record GetMonthlyTasksQuery(int Month) : IQuery<List<GetMonthlyTasksResponse>>;

	public class GetMonthlyTasksQueryHandler : IQueryHandler<GetMonthlyTasksQuery, List<GetMonthlyTasksResponse>>
	{
		private readonly IMonthlyTasksRepository _repository;

		public GetMonthlyTasksQueryHandler(IMonthlyTasksRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetMonthlyTasksResponse>> Handle(GetMonthlyTasksQuery query, CancellationToken cancellationToken)
		{
			// 設定查詢的時間範圍
			var year = DateTime.Now.Year;
			var startDate = new DateTime(year, query.Month, 1);
			var endDate = startDate.AddMonths(1);

			var res = await _repository.QueryMonthlyTasksAsync(startDate, endDate);
			return res;
		}
	}
}
