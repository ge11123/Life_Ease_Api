using LifeManage.src.Application.Handlers.Weather;
using LifeManage.src.Application.Queries.Weather;

namespace LifeManage.src.Application.Services.Interfaces
{
	public interface IWeatherServices
	{
		/// <summary>
		/// 一般天氣預報-今明 36 小時天氣預報
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		Task<GetTwoDaysWeatherResponse> GetTwoDaysWeatherAsync(GetTwoDaysForecastQuery query);
	}
}
