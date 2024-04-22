using LifeManage.src.Application.Handlers;
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
			if (query.IsDone != null)
			{
				expression = expression.And(x => x.IsDone == query.IsDone);
			}

			if (query.CreateTime != null)
			{
				expression = expression.And(x => x.CreateDate == query.CreateTime);
			}

			if (query.Id != null)
			{
				expression = expression.And(x => x.Id == query.Id);
			}

			return expression;
		}
	}
}
