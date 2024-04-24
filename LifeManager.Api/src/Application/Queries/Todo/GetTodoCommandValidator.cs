using FluentValidation;
using LifeManage.src.Application.Handlers;
using System.Data;

namespace LifeManage.src.Application.Queries.Todo
{
	public class GetTodoCommandValidator : AbstractValidator<GetTodoQuery>
	{
        public GetTodoCommandValidator()
        {
			RuleFor(todo => todo.IsDone).NotEmpty().WithMessage("not be null");
			RuleFor(todo => todo.Id).NotEmpty().WithMessage("not be null");
		}
	}
}
