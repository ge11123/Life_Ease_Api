using AutoMapper;
using LifeManage.src.Application.Commands.Interface;
using LifeManage.src.Application.Exceptions;
using LifeManage.src.Application.Handlers.Interface;
using LifeManage.src.Domain.Entities;
using LifeManage.src.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace LifeManage.src.Application.Handlers.Todo
{
	public record CreateTodoCommand(bool? IsCompleted, string Title, string? Description, DateTime? DueDate) : ICommand<Unit>;

	public class CreateTodoCommandHandler : ICommandHandler<CreateTodoCommand, Unit>
	{
		private readonly ITodoRepository _todoRepository;
		private readonly IMapper _mapper;

		public CreateTodoCommandHandler(ITodoRepository todoRepository, IMapper mapper)
		{
			_todoRepository = todoRepository;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(CreateTodoCommand command, CancellationToken cancellationToken)
		{
			try
			{
				await _todoRepository.InsertAsync(_mapper.Map<TodoList>(command));
			}
			catch (Exception e)
			{
				throw new CreatedException(e.Message);
			}
			return Unit.Value;
		}
	}
}
