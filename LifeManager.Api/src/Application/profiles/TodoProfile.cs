﻿using AutoMapper;
using LifeManage.src.Application.Handlers.Todo;
using LifeManage.src.Application.Queries.Todo;
using LifeManage.src.Domain.Entities;

namespace LifeManage.src.Application.profiles
{
	public class TodoProfile : Profile
	{
		public TodoProfile()
		{
			CreateMap<TodoList, TodoList>();

			CreateMap<TodoList, GetTodoResponse>().ReverseMap();

			CreateMap<TodoList, GetTodoByIdResponse>().ReverseMap();

			CreateMap<UpdateTodoCommand, TodoList>().ReverseMap();

			CreateMap<CreateTodoCommand, TodoList>()
				.ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.Now))
				.ReverseMap();

			CreateMap<DeleteTodoCommand, TodoList>().ReverseMap();

		}
	}
}
