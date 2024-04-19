using AutoMapper;
using LifeManage.src.Application.Queries.Todo;
using LifeManage.src.Domain.entities;

namespace LifeManage.src.Application.profiles
{
	public class TodoProfile : Profile
	{
		public TodoProfile()
		{
			CreateMap<TodoList, GetTodoResponse>();
		}
	}
}
