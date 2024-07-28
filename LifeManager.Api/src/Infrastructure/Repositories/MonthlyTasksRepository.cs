using AutoMapper;
using LifeManage.src.Application.Queries.MonthlyTasks;
using LifeManage.src.Domain;
using LifeManage.src.Domain.Entities;
using LifeManage.src.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;

namespace LifeManage.src.Infrastructure.Repositories
{
	public class MonthlyTasksRepository : LifeManageRepository<TodoList>, IMonthlyTasksRepository
	{
		private readonly LifeEaseDbContext _context;
		private readonly IMapper _mapper;

		public MonthlyTasksRepository(LifeEaseDbContext context, IMapper mapper, ClaimsPrincipal clams) : base(context, mapper, clams)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<List<GetMonthlyTasksResponse>> QueryMonthlyTasksAsync(Expression<Func<TodoList, bool>> predicate)
		{
			var query = _context.TodoList
							 .Where(predicate)
							 .OrderBy(todo => todo.DueDate);

			return await _mapper.ProjectTo<GetMonthlyTasksResponse>(query).ToListAsync();
		}
	}
}
