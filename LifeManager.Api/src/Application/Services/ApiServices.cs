using LifeManage.src.Application.Exceptions;
using LifeManage.src.Application.Services.Interfaces;

namespace LifeManage.src.Application.Services
{
	public class ApiServices(IHttpClientFactory httpClientFactory) : IApiServices
	{
		private readonly HttpClient _httpClient = httpClientFactory.CreateClient();

		/// <summary>
		/// http get
		/// </summary>
		/// <typeparam name="TResult">返回資料</typeparam>
		/// <param name="baseUrl">目標網址</param>
		/// <param name="queryParams">http get 的查詢參數</param>
		/// <returns>目標網址的資料</returns>
		/// <exception cref="NotFoundException">查無資料</exception>
		/// <exception cref="Exception">系統異常</exception>
		public async Task<TResult> GetDataAsync<TResult>(string baseUrl, IDictionary<string, string> queryParams)
		{
			var uriBuilder = new UriBuilder(baseUrl);

			// 添加查詢參數
			var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
			foreach (var param in queryParams)
			{
				query[param.Key] = param.Value;
			}

			uriBuilder.Query = query.ToString();
			var fullUrl = uriBuilder.ToString();

			var response = await _httpClient.GetAsync(fullUrl);
			response.EnsureSuccessStatusCode();

			if (response.IsSuccessStatusCode)
			{
				return await response.Content.ReadFromJsonAsync<TResult>()
					?? throw new NotFoundException();
			}

			throw new Exception();
		}
	}
}
