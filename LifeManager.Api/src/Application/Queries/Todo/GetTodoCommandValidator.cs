using FluentValidation;
using LifeManage.src.Application.Handlers.Todo;

namespace LifeManage.src.Application.Queries.Todo
{
	public class GetTodoCommandValidator : AbstractValidator<GetTodoQuery>
	{
		public GetTodoCommandValidator()
		{
			RuleFor(x => x.Id).NotEmpty().WithMessage("ID is required");
		}
	}
}
