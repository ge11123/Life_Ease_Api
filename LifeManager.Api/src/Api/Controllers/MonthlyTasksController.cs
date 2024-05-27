using LifeManage.src.Application.Handlers.MonthlyTasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LifeManage.src.Api.Controllers
{
	public class MonthlyTasksController : BaseController
	{
		private readonly IMediator _mediator;

		public MonthlyTasksController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("{month}")]
		public async Task<IActionResult> GetMonthlyTasks([FromRoute] int month)
		{
			return HandleResult(await _mediator.Send(new GetMonthlyTasksQuery(month)));
		}

	}
}
