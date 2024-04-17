namespace LifeManage.src.Infrastructure.BaseModels
{
	public class PageResult<T>
	{
		public IEnumerable<T> Items { get; set; } = new HashSet<T>();

		public int Total { get; set; } = 0;

		public PageResult()
		{

		}

		public PageResult(IEnumerable<T> items, int totalCount)
		{
			Items = items;
			Total = totalCount;

		}
	}
}
