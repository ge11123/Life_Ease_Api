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
		[Route("{title}")]
		public async Task<IActionResult> GetTodoByTitle([FromRoute] string title)
		{
			return HandleResult(await _mediator.Send(new GetTodoByTitleQuery(title)));
		}

		[HttpGet]
		public async Task<IActionResult> GetTodos([FromQuery] GetTodoQuery query)
		{
			return HandleResult(await _mediator.Send(query));
		}

		[HttpPost]
		public async Task<IActionResult> CreateTodo([FromBody] CreateTodoCommand command)
		{
			return HandleCreationResult(await _mediator.Send(command));
		}

		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> UpdateTodo([FromRoute] int id, [FromBody] UpdateTodoRequest req)
		{
			var command = new UpdateTodoCommand(id, req.IsCompleted, req.Title, req.Description);
			return HandleModifyResult(await _mediator.Send(command));
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> DeleteTodo([FromRoute] int id)
		{
			var command = new DeleteTodoCommand(id);
			return HandleModifyResult(await _mediator.Send(command));
		}
	}
}
