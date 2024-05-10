using LifeManage.src.Application.Handlers.Interface;
using LifeManage.src.Application.Queries.Interface;
using LifeManage.src.Application.Queries.Weather;
using LifeManage.src.Application.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace LifeManage.src.Application.Handlers.Weather
{
	public record GetTwoDaysForecastQuery(string LocationName) : IQuery<GetTwoDaysWeatherResponse?>;

	public class GetTwoDaysForecastQueryHandler : IQueryHandler<GetTwoDaysForecastQuery, GetTwoDaysWeatherResponse?>
	{
		private readonly IWeatherServices _weatherServices;
		private readonly IMemoryCache _memoryCache;


		public GetTwoDaysForecastQueryHandler(IWeatherServices weatherServices, IMemoryCache memoryCache)
		{
			_weatherServices = weatherServices;
			_memoryCache = memoryCache;
		}


		public async Task<GetTwoDaysWeatherResponse?> Handle(GetTwoDaysForecastQuery query, CancellationToken cancellationToken)
		{
			var cacheKey = $"WeatherForecast-{query.LocationName}";

			var cacheEntryOptions = new MemoryCacheEntryOptions();

			// setting sliding expiration to 1 hour
			cacheEntryOptions.SetSlidingExpiration(TimeSpan.FromHours(12));

			// catch value from cache if exist
			var forecast = await _memoryCache.GetOrCreateAsync(cacheKey, async entry =>
			{
				entry.SetOptions(cacheEntryOptions);
				return await _weatherServices.GetTwoDaysWeatherAsync(query);
			});

			return forecast;
		}
	}
}
