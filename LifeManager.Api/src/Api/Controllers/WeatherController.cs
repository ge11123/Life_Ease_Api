using LifeManage.src.Application.Handlers.Weather;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LifeManage.src.Api.Controllers
{
	public class WeatherController : BaseController
	{
		private readonly IMediator _mediator;

		public WeatherController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[Route("twoDaysForecast")]
		public async Task<IActionResult> GetTwoDaysWeather([FromQuery] string county)
		{
			return Ok(await _mediator.Send(new GetTwoDaysForecastQuery(county)));
		}
	}
}
