using LifeManage.src.Application.Handlers.Interface;
using LifeManage.src.Application.Queries.Interface;
using LifeManage.src.Application.Queries.SidebarMenu;
using LifeManage.src.Infrastructure.Repositories.Interfaces;

namespace LifeManage.src.Application.Handlers.Menu
{
	public record GetMenuQuery() : IQuery<List<GetSidebarMenuResponse>>;
	public class GetMenuQueryHandler : IQueryHandler<GetMenuQuery, List<GetSidebarMenuResponse>>
	{
		private readonly ISidebarMenuRepository _sidebarRepository;

		public GetMenuQueryHandler(ISidebarMenuRepository sidebarRepository)
		{
			_sidebarRepository = sidebarRepository;
		}

		public async Task<List<GetSidebarMenuResponse>> Handle(GetMenuQuery request, CancellationToken cancellationToken)
		{
			return await _sidebarRepository.GetSidebarMenu();
		}
	}
}
