using AutoMapper;
using LifeManage.src.Application.Commands.Interface;
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
		private readonly IMapper _mapper;

		public DeleteTodoCommandHandler(ITodoRepository todoRepository, IMapper mapper)
		{
			_todoRepository = todoRepository;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(DeleteTodoCommand command, CancellationToken cancellationToken)
		{
			var todo = await _todoRepository.FirstOrDefaultAsync<TodoList>(x => x.Id == command.Id);
			await _todoRepository.DeleteAsync(todo);
			return Unit.Value;
		}
	}
}
