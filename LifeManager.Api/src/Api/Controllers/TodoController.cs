using LifeManage.src.Application.Commands.Todo;
using LifeManage.src.Application.Handlers.Todo;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
		public async Task<IActionResult> GetTodos([FromQuery] GetTodoQuery query)
		{
			return HandleResult(await _mediator.Send(query));
		}

		[HttpPost]
		public async Task<IActionResult> CreateTodo([FromBody] CreateTodoCommand command)
		{
			return HandleResult(await _mediator.Send(command));
		}

		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> UpdateTodo([FromRoute] int id, [FromBody] UpdateTodoRequest req)
		{
			var command = new UpdateTodoCommand(id, req.IsCompleted, req.Title, req.Description);
			return HandleResult(await _mediator.Send(command));
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> DeleteTodo([FromRoute] int id)
		{
			var command = new DeleteTodoCommand(id);
			return HandleResult(await _mediator.Send(command));
		}
	}
}
