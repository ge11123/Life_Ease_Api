using LifeManage.src.Application.Handlers.Menu;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LifeManage.src.Api.Controllers
{
	public class MenuController : BaseController
	{
		private readonly IMediator _mediator;

		public MenuController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetMenu()
		{
			return HandleResult(await _mediator.Send(new GetMenuQuery()));
		}
	}
}
