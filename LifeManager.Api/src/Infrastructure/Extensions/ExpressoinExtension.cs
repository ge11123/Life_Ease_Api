using System.Linq.Expressions;

namespace LifeManage.src.Infrastructure.Extensions
{
	class ParameterRebinder : ExpressionVisitor
	{
		private readonly Dictionary<ParameterExpression, ParameterExpression> _map;

		public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
		{
			_map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
		}

		public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
		{
			return new ParameterRebinder(map).Visit(exp);
		}

		protected override Expression VisitParameter(ParameterExpression p)
		{
			if (_map.TryGetValue(p, out var replacement))
			{
				p = replacement;
			}

			return base.VisitParameter(p);
		}
	}

	public static class ExpressoinExtension
	{
		public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
		{
			if (first == null || second == null)
			{
				return first ?? second ?? null;
			}

			return first.Compose(second, Expression.AndAlso);
		}

		public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
		{
			if (first == null || second == null)
			{
				return first ?? second ?? null;
			}

			return first.Compose(second, Expression.OrElse);
		}

		private static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
		{
			// build parameter map (from parameters of second to parameters of first)
			var map = first.Parameters
				.Select((f, i) => new { f, s = second.Parameters[i] })
				.ToDictionary(p => p.s, p => p.f);

			// replace parameters in the second lambda expression with parameters from the first
			var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

			// apply composition of lambda expression bodies to parameters from the first expression 
			return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
		}
	}
}
