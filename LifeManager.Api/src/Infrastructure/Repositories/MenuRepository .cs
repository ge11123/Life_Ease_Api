using AutoMapper;
using LifeManage.src.Application.Queries.SidebarMenu;
using LifeManage.src.Domain;
using LifeManage.src.Domain.entities;
using LifeManage.src.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LifeManage.src.Infrastructure.Repositories
{
	public class SidebarMenuRepository : LifeManageRepository<SidebarMenu>, ISidebarMenuRepository
	{
		private readonly LifeEaseDbContext _context;
		private readonly IMapper _mapper;
		public SidebarMenuRepository(LifeEaseDbContext context, IMapper mapper, ClaimsPrincipal clams) : base(context, mapper, clams)
		{
			_mapper = mapper;
			_context = context;
		}

		public async Task<List<GetSidebarMenuResponse>> GetSidebarMenu()
		{
			// 所有資料
			var sidebarMenus = await _context.SidebarMenu.ToListAsync();

			// 只含父類層
			var parentsMenu = sidebarMenus.Where(m => m.ParentId == null).OrderBy(m => m.Order);

			var response = new List<GetSidebarMenuResponse>();
			foreach (var parent in parentsMenu)
			{
				response.Add(BuildMenuTree(parent, sidebarMenus));
			}

			return response;
		}

		private GetSidebarMenuResponse BuildMenuTree(SidebarMenu parent, List<SidebarMenu> allMenus)
		{
			// 先將父類層資料裝起來
			var response = _mapper.Map<GetSidebarMenuResponse>(parent);

			// 找出符合父類層的子類層
			var childMenus = allMenus.Where(m => m.ParentId == parent.Id).OrderBy(m => m.Order);
			foreach (var childMenu in childMenus)
			{
				// 用 loop+遞迴 裝到 Children 裡
				response.Children.Add(BuildMenuTree(childMenu, allMenus));
			}

			return response;
		}
	}
}
