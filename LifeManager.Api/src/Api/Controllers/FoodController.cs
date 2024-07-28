using LifeManage.src.Application.Handlers.Menu;
using LifeManage.src.Application.Handlers.Restaurant;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LifeManage.src.Api.Controllers
{
	public class FoodController : BaseController
	{
		private readonly IMediator _mediator;

		public FoodController(IMediator mediator)
		{
			_mediator = mediator;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[Route("restaurant")]
		[HttpPost]
		public async Task<IActionResult> CreateRestaurant()
		{
			return HandleResult(await _mediator.Send(new CreateRestaurantCommand()));
		}
	}
}
