using AutoMapper;
using LifeManage.src.Domain;
using LifeManage.src.Domain.entities;
using LifeManage.src.Infrastructure.Repositories.Interfaces;
using System.Security.Claims;

namespace LifeManage.src.Infrastructure.Repositories
{
	public class TodoRepository : LifeManageRepository<TodoList>, ITodoRepository
	{
		public TodoRepository(LifeEaseDbContext context, IMapper mapper, ClaimsPrincipal clams) : base(context, mapper, clams)
		{
		}
	}
}
