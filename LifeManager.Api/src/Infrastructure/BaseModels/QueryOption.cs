namespace LifeManage.src.Infrastructure.BaseModels
{
	public record QueryOption
	{
		/// <summary>
		/// 筆數
		/// </summary>
		public int? PageSize { get; set; } = 20;

		/// <summary>
		/// 頁碼
		/// </summary>
		public int? PageNumber { get; set; } = 1;

		public IQueryable<T> ApplyTo<T>(IQueryable<T> query)
		{
			if (PageNumber.HasValue && PageSize.HasValue)
			{
				query = query.Skip((PageNumber.Value - 1) * PageSize.Value).Take(PageSize.Value);
			}

			return query;
		}
	}
}
