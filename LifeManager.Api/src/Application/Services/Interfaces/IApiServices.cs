namespace LifeManage.src.Application.Services.Interfaces
{
	public interface IApiServices
	{
		/// <summary>
		/// http get
		/// </summary>
		/// <typeparam name="TResult">返回資料</typeparam>
		/// <param name="baseUrl">目標網址</param>
		/// <param name="queryParams">http get 的查詢參數</param>
		/// <returns>目標網址的資料</returns>
		/// <exception cref="NotFoundException">查無資料</exception>
		/// <exception cref="Exception">系統異常</exception>
		Task<TResult> GetDataAsync<TResult>(string baseUrl, IDictionary<string, string> queryParams);
	}
}
