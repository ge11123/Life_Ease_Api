namespace LifeManage.src.Application.Queries.SidebarMenu
{
	public class GetSidebarMenuResponse
	{
		public int Id { get; set; }

		public string Title { get; set; } = null!;

		public string? Icon { get; set; }

		public string Url { get; set; } = null!;

		public int? ParentId { get; set; }

		public int? Order { get; set; }

		public string? Permission { get; set; }

		public string? Description { get; set; }

		public virtual ICollection<GetSidebarMenuResponse> Children { get; set; } = [];
	}
}
