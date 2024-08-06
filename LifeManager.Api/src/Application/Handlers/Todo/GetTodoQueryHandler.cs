using LifeManage.src.Application.Handlers.Interface;
using LifeManage.src.Application.Queries.Interface;
using LifeManage.src.Application.Queries.Todo;
using LifeManage.src.Domain.Entities;
using LifeManage.src.Infrastructure.BaseModels;
using LifeManage.src.Infrastructure.Repositories.Interfaces;
using LifeManage.src.Infrastructure.Extensions;
using System.Linq.Expressions;

namespace LifeManage.src.Application.Handlers.Todo
{
	public record GetTodoQuery(int? Id, DateTime? CreateTime, bool? IsCompleted, DateTime? DueTime, string? Title) 
        : IQuery<PageResult<GetTodoResponse>>;

	public class GetTodoQueryHandler : IQueryHandler<GetTodoQuery, PageResult<GetTodoResponse>>
	{
		private readonly ITodoRepository _todoRepository;

		public GetTodoQueryHandler(ITodoRepository todoRepository)
		{
			_todoRepository = todoRepository;
		}

		public async Task<PageResult<GetTodoResponse>> Handle(GetTodoQuery query, CancellationToken cancellationToken)
		{
			var predicate = GenerateTodoFilter(query);
			var res = await _todoRepository.QueryAsync<GetTodoResponse>(predicate, query);

			return res;
		}

        private static Expression<Func<TodoList, bool>> GenerateTodoFilter(GetTodoQuery query)
        {
            Expression<Func<TodoList, bool>> expression = x => true;
            if (query.IsCompleted != null)
            {
                expression = expression.And(x => x.IsCompleted == query.IsCompleted);
            }

            if (query.CreateTime != null)
            {
                expression = expression.And(x => x.CreateDate == query.CreateTime);
            }

            if (query.Id != null)
            {
                expression = expression.And(x => x.Id == query.Id);
            }

            if (query.DueTime != null)
            {
                expression = expression.And(x => x.DueDate == query.DueTime);
            }

            if (!string.IsNullOrWhiteSpace(query.Title))
            {
                expression = expression.And(x => x.Title.Contains(query.Title));
            }

            return expression;
        }
    }
}
