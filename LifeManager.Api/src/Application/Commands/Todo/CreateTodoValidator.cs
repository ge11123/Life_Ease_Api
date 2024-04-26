using FluentValidation;
using LifeManage.src.Application.Handlers.Todo;

namespace LifeManage.src.Application.Commands.Todo
{
	public class CreateTodoValidator : AbstractValidator<CreateTodoCommand>
	{
		public CreateTodoValidator()
		{
			RuleFor(x => x.Title)
				.NotEmpty()
				.WithMessage("Title is required");
		}
	}
}
