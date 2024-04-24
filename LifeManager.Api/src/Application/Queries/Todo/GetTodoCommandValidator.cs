using FluentValidation;
using LifeManage.src.Application.Handlers;

namespace LifeManage.src.Application.Queries.Todo
{
	public class GetTodoCommandValidator : AbstractValidator<GetTodoQuery>
	{
		public GetTodoCommandValidator()
		{
		}
	}
}
