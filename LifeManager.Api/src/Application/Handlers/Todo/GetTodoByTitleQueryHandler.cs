using LifeManage.src.Application.Exceptions;
using LifeManage.src.Application.Handlers.Interface;
using LifeManage.src.Application.Queries.Interface;
using LifeManage.src.Application.Queries.Todo;
using LifeManage.src.Infrastructure.BaseModels;
using LifeManage.src.Infrastructure.Repositories.Interfaces;

namespace LifeManage.src.Application.Handlers.Todo
{
	public record GetTodoByTitleQuery(string Title) : IQuery<PageResult<GetTodoByTitleResponse>>;

	public class GetTodoByTitleQueryHandler : IQueryHandler<GetTodoByTitleQuery, PageResult<GetTodoByTitleResponse>>
	{
		private readonly ITodoRepository _todoRepository;

		public GetTodoByTitleQueryHandler(ITodoRepository todoRepository)
		{
			_todoRepository = todoRepository;
		}

		public async Task<PageResult<GetTodoByTitleResponse>> Handle(GetTodoByTitleQuery query, CancellationToken cancellationToken)
		{
			var res = await _todoRepository.QueryAsync<GetTodoByTitleResponse>(x => x.Title.Contains(query.Title), query) 
				?? throw new NotFoundException();

			return res;
		}
	}
}
