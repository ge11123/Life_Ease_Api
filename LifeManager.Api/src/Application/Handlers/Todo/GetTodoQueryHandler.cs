using LifeManage.src.Application.Handlers.Interface;
using LifeManage.src.Application.Queries.Interface;
using LifeManage.src.Application.Queries.Todo;
using LifeManage.src.Infrastructure.BaseModels;
using LifeManage.src.Infrastructure.Repositories.Interfaces;

namespace LifeManage.src.Application.Handlers.Todo
{
	public record GetTodoQuery(int? Id, DateTime? CreateTime, bool? IsCompleted, DateTime? DueTime) : IQuery<PageResult<GetTodoResponse>>;

	public class GetTodoQueryHandler : IQueryHandler<GetTodoQuery, PageResult<GetTodoResponse>>
	{
		private readonly ITodoRepository _todoRepository;

		public GetTodoQueryHandler(ITodoRepository todoRepository)
		{
			_todoRepository = todoRepository;
		}

		public async Task<PageResult<GetTodoResponse>> Handle(GetTodoQuery query, CancellationToken cancellationToken)
		{
			var predicate = new GetTodoListExpressions().Expression(query);
			var res = await _todoRepository.QueryAsync<GetTodoResponse>(predicate, query);

			return res;
		}
	}
}
