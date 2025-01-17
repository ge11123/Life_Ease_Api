﻿using AutoMapper;
using LifeManage.src.Application.Queries.SidebarMenu;
using LifeManage.src.Domain.Entities;

namespace LifeManage.src.Application.profiles
{
	public class SidebarMenuProfile : Profile
	{
		public SidebarMenuProfile()
		{
			CreateMap<SidebarMenu, GetSidebarMenuResponse>();
			CreateMap<SidebarMenu, SidebarMenu>();
		}
	}
}
