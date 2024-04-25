using AutoMapper;
using LifeManage.src.Application.Commands.Interface;
using LifeManage.src.Application.Handlers.Interface;
using LifeManage.src.Domain.entities;
using LifeManage.src.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace LifeManage.src.Application.Handlers.Todo
{
	public record UpdateTodoCommand(int Id, bool? IsCompleted, string? Title, string? Description) : ICommand<Unit>;

	public class UpdateTodoCommandHandler : ICommandHandler<UpdateTodoCommand, Unit>
	{
		private readonly ITodoRepository _todoRepository;
		private readonly IMapper _mapper;

		public UpdateTodoCommandHandler(ITodoRepository todoRepository, IMapper mapper)
		{
			_todoRepository = todoRepository;
			_mapper = mapper;
		}

		public async Task<Unit> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
		{
			await _todoRepository.UpdateTodoAsync(_mapper.Map<TodoList>(request));
			return Unit.Value;
		}
	}
}
