using AutoMapper;
using LifeManage.src.Application.Handlers.Interface;
using LifeManage.src.Application.Queries.Interface;
using LifeManage.src.Application.Queries.Todo;
using LifeManage.src.Domain;
using LifeManage.src.Infrastructure.Repositories;
using LifeManage.src.Infrastructure.Repositories.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LifeManage.src.Application.Handlers
{
	public record GetTodoCommand : IQuery<List<GetTodoResponse>>;

	public class GetTodoQueryHandler : IQueryHandler<GetTodoCommand, List<GetTodoResponse>>
	{
		private readonly LifeEaseDbContext _context;
		private readonly IMapper _mapper;
		private readonly ITodoRepository _todoRepository;

		public GetTodoQueryHandler(LifeEaseDbContext context, IMapper mapper, ITodoRepository todoRepository)
		{
			_context = context;
			_mapper = mapper;
			_todoRepository = todoRepository;
		}

		public async Task<List<GetTodoResponse>> Handle(GetTodoCommand request, CancellationToken cancellationToken)
		{
			var res = await _todoRepository.QueryAsync<GetTodoResponse>(x => x.IsDone);

			return res;
		}
	}
}
