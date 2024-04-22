using LifeManage.src.Application.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LifeManage.src.Api.Controllers
{
	public class TodoController : BaseController
	{
		private readonly IMediator _mediator;

		public TodoController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> GetTodoIsDone([FromBody] GetTodoQuery req)
		{
			return HandleResult(await _mediator.Send(req));
		}

		//[HttpPost]
		//public IActionResult Post()
		//{
		//	return Ok("Hello World");
		//}

		[HttpPut]
		public IActionResult Put()
		{
			return Ok("Hello World");
		}

		[HttpDelete]
		public IActionResult Delete()
		{
			return Ok("Hello World");
		}
	}
}
