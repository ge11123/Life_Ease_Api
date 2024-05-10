using LifeManage.src.Application.Queries.SidebarMenu;
using LifeManage.src.Domain.entities;

namespace LifeManage.src.Infrastructure.Repositories.Interfaces
{
	public interface ISidebarMenuRepository : IGenericRepository<SidebarMenu>
	{
		Task<List<GetSidebarMenuResponse>> GetSidebarMenu();
	}
}
