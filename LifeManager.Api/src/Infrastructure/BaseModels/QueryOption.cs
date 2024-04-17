namespace LifeManage.src.Infrastructure.BaseModels
{
	public class QueryOption
	{
		/// <summary>
		/// 筆數
		/// </summary>
		public int? Limit { get; set; } = 20;

		/// <summary>
		/// 頁碼
		/// </summary>
		public int? Offset { get; set; } = 0;

		public string Orderby { get; set; } = "CreateDate:Desc";

		public IQueryable<T> ApplyTo<T>(IQueryable<T> query)
		{
			if (string.IsNullOrWhiteSpace(Orderby) == false)
			{
				//用分號區隔要排序的欄位及正/倒序
				string[] order = Orderby.Split(':');

				//取得排序欄位
				var orderName = order[0];

				//取得是否倒序，如果:後方無值則視為正序
				var orderSort = "";
				if (order.Length > 1) orderSort = order[1];

				if ("Desc".Equals(orderSort))
				{
					//如果是要倒序，則在欄位名稱後方加上" descending"
					query = query.OrderByDescending(x => orderName);
				}
				else
				{
					query = query.OrderBy(x => orderName);
				}
			}

			if (Offset.HasValue)
			{
				query = query.Skip((Offset.Value));
			}

			if (Limit.HasValue)
			{
				query = query.Take(Limit.Value);
			}

			return query;
		}
	}
}
