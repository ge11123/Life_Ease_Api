using AutoMapper;
using LifeManage.src.Application.Handlers.Interface;
using LifeManage.src.Application.Queries.Interface;
using LifeManage.src.Application.Queries.Todo;
using LifeManage.src.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LifeManage.src.Application.Handlers
{
    public record GetTodoCommand : IQuery<List<GetTodoResponse>>;

	public class GetTodoQueryHandler : IQueryHandler<GetTodoCommand, List<GetTodoResponse>>
	{
		private readonly LifeEaseDbContext _context;
		private readonly IMapper _mapper;

		public GetTodoQueryHandler(LifeEaseDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<List<GetTodoResponse>> Handle(GetTodoCommand request, CancellationToken cancellationToken)
		{
			var todos = _context.TodoList.Where(todo => todo.IsDone);
			var res = _mapper.ProjectTo<GetTodoResponse>(todos);

			return await res.ToListAsync(cancellationToken: cancellationToken);
		}
	}
}
