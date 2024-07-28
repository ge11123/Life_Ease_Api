using AutoMapper;
using LifeManage.src.Domain;
using LifeManage.src.Domain.Entities;
using LifeManage.src.Infrastructure.Repositories.Interfaces;
using System.Security.Claims;

namespace LifeManage.src.Infrastructure.Repositories
{
	public class TodoRepository : LifeManageRepository<TodoList>, ITodoRepository
	{
		private readonly LifeEaseDbContext _context;
		public TodoRepository(LifeEaseDbContext context, IMapper mapper, ClaimsPrincipal clams) : base(context, mapper, clams)
		{
			_context = context;
		}


		public async Task UpdateTodoAsync(TodoList todoList)
		{
			_context.Entry(todoList).Property(x => x.IsCompleted).IsModified = true;
			_context.Entry(todoList).Property(x => x.Description).IsModified = true;

			if (!string.IsNullOrWhiteSpace(todoList.Title))
			{
				_context.Entry(todoList).Property(x => x.Title).IsModified = true;
			}

			await _context.SaveChangesAsync();
		}
	}
}
