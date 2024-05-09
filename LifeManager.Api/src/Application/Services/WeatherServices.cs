using LifeManage.src.Application.Handlers.Weather;
using LifeManage.src.Application.Queries.Weather;
using LifeManage.src.Application.Services.Interfaces;

namespace LifeManage.src.Application.Services
{
	public class WeatherServices : IWeatherServices
	{
		private readonly IApiServices _apiServices;
		public WeatherServices(IApiServices apiServices)
		{
			_apiServices = apiServices;
		}

		/// <summary>
		/// 一般天氣預報-今明 36 小時天氣預報
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		public async Task<GetTwoDaysWeatherResponse> GetTwoDaysWeatherAsync(GetTwoDaysForecastQuery query)
		{
			string baseUrl = "https://opendata.cwa.gov.tw/api/v1/rest/datastore/F-C0032-001";

			var queryParams = new Dictionary<string, string>
			{
				{ "Authorization", "CWA-E625299F-CCB3-4E46-8ACD-142DEBA3D00C" },
				{ "locationName", query.LocationName }
			};

			return await _apiServices.GetDataAsync<GetTwoDaysWeatherResponse>(baseUrl, queryParams);
		}


	}
}
