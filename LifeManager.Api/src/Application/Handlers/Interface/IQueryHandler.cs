using LifeManage.src.Application.Queries.Interface;
using MediatR;

namespace LifeManage.src.Application.Handlers.Interface
{
	public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
	{

	}
}
