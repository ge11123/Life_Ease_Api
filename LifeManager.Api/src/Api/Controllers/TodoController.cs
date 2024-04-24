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

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetTodoById(int id)
		{
			return HandleResult(await _mediator.Send(new GetTodoByIdQuery(id)));
		}

		[HttpGet]
		public async Task<IActionResult> GetTodos([FromQuery] GetTodoQuery req)
		{
			return HandleResult(await _mediator.Send(req));
		}

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
