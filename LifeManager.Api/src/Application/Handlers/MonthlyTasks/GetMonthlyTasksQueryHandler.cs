using LifeManage.src.Application.Handlers.Interface;
using LifeManage.src.Application.Queries.Interface;
using LifeManage.src.Application.Queries.MonthlyTasks;
using LifeManage.src.Domain.entities;
using LifeManage.src.Infrastructure.Repositories.Interfaces;
using System.Linq.Expressions;

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
            var predicate = GenerateMonthlyTaskFilter(query);
            return await _repository.QueryMonthlyTasksAsync(predicate);
        }

        private static Expression<Func<TodoList, bool>> GenerateMonthlyTaskFilter(GetMonthlyTasksQuery query)
        {
            var year = DateTime.Now.Year;
            var startDate = new DateTime(year, query.Month, 1);
            var endDate = startDate.AddMonths(1);

            return todo => todo.DueDate >= startDate && todo.DueDate < endDate;
        }
    }
}
