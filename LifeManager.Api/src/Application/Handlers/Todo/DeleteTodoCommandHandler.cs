using LifeManage.src.Application.Commands.Interface;
using LifeManage.src.Application.Exceptions;
using LifeManage.src.Application.Handlers.Interface;
using LifeManage.src.Domain.entities;
using LifeManage.src.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace LifeManage.src.Application.Handlers.Todo
{
	public record DeleteTodoCommand(int Id) : ICommand<Unit>;

	public class DeleteTodoCommandHandler : ICommandHandler<DeleteTodoCommand, Unit>
	{
		private readonly ITodoRepository _todoRepository;

		public DeleteTodoCommandHandler(ITodoRepository todoRepository)
		{
			_todoRepository = todoRepository;
		}

		public async Task<Unit> Handle(DeleteTodoCommand command, CancellationToken cancellationToken)
		{
			var todo = await _todoRepository.FirstOrDefaultAsync<TodoList>(x => x.Id == command.Id)
				?? throw new NotFoundException();

			try
			{
				await _todoRepository.DeleteAsync(todo);
			}
			catch (Exception e)
			{
				throw new ModifyDataException(e.Message);
			}

			return Unit.Value;
		}
	}
}
