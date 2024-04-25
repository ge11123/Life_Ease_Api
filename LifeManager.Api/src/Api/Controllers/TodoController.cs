using LifeManage.src.Application.Commands.Todo;
using LifeManage.src.Application.Handlers.Todo;
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
		public async Task<IActionResult> GetTodoById([FromRoute] int id)
		{
			return HandleResult(await _mediator.Send(new GetTodoByIdQuery(id)));
		}

		[HttpGet]
		public async Task<IActionResult> GetTodos([FromQuery] GetTodoQuery req)
		{
			return HandleResult(await _mediator.Send(req));
		}

		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> UpdateTodo([FromRoute] int id, [FromBody] UpdateTodoRequest req)
		{
			var command = new UpdateTodoCommand(id, req.IsCompleted, req.Title, req.Description);
			return HandleResult(await _mediator.Send(command));
		}

		[HttpDelete]
		public IActionResult Delete()
		{
			return Ok("Hello World");
		}
	}
}
