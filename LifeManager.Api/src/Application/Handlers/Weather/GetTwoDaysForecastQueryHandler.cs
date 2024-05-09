using LifeManage.src.Application.Handlers.Interface;
using LifeManage.src.Application.Queries.Interface;
using LifeManage.src.Application.Queries.Weather;
using LifeManage.src.Application.Services.Interfaces;

namespace LifeManage.src.Application.Handlers.Weather
{
	public record GetTwoDaysForecastQuery(string LocationName) : IQuery<GetTwoDaysWeatherResponse>;

	public class GetTwoDaysForecastQueryHandler : IQueryHandler<GetTwoDaysForecastQuery, GetTwoDaysWeatherResponse>
	{
		private readonly IWeatherServices _weatherServices;
		public GetTwoDaysForecastQueryHandler(IWeatherServices weatherServices)
		{
			_weatherServices = weatherServices;
		}


		public async Task<GetTwoDaysWeatherResponse> Handle(GetTwoDaysForecastQuery query, CancellationToken cancellationToken)
		{
			return await _weatherServices.GetTwoDaysWeatherAsync(query);
		}
	}
}
