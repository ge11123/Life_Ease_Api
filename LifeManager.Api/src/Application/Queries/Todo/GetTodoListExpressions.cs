using LifeManage.src.Application.Handlers.Todo;
using LifeManage.src.Domain.entities;
using LifeManage.src.Infrastructure.Extensions;
using System.Linq.Expressions;

namespace LifeManage.src.Application.Queries.Todo
{
	public class GetTodoListExpressions
	{
		public Expression<Func<TodoList, bool>> Expression(GetTodoQuery query)
		{
			Expression<Func<TodoList, bool>> expression = x => true;
			if (query.IsCompleted != null)
			{
				expression = expression.And(x => x.IsCompleted == query.IsCompleted);
			}

			if (query.CreateTime != null)
			{
				expression = expression.And(x => x.CreateDate == query.CreateTime);
			}

			if (query.Id != null)
			{
				expression = expression.And(x => x.Id == query.Id);
			}

			if (query.DueTime != null)
			{
				expression = expression.And(x => x.DueDate == query.DueTime);
			}

			return expression;
		}
	}
}
