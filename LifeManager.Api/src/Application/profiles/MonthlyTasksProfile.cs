using AutoMapper;
using LifeManage.src.Application.Queries.MonthlyTasks;
using LifeManage.src.Domain.entities;

namespace LifeManage.src.Application.profiles
{
	public class MonthlyTasksProfile : Profile
	{
		public MonthlyTasksProfile()
		{
			CreateMap<TodoList, GetMonthlyTasksResponse>();
		}
	}
}
