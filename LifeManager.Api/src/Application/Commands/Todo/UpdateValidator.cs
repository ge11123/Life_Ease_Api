using FluentValidation;
using LifeManage.src.Application.Handlers.Todo;
using System.Data;

namespace LifeManage.src.Application.Commands.Todo
{
	public class UpdateValidator : AbstractValidator<UpdateTodoCommand>
	{
		public UpdateValidator()
		{
			RuleFor(x => x.IsCompleted)
				.NotEmpty()
				.WithMessage("IsCompleted is required");
		}
	}
}
