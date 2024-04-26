using FluentValidation;
using LifeManage.src.Application.Handlers.Todo;

namespace LifeManage.src.Application.Commands.Todo
{
	public class UpdateTodoValidator : AbstractValidator<UpdateTodoCommand>
	{
		public UpdateTodoValidator()
		{
			RuleFor(x => x.IsCompleted)
				.NotEmpty()
				.WithMessage("IsCompleted is required");
		}
	}
}
