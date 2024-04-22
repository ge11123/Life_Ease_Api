using LifeManage.src.Infrastructure.BaseModels;
using MediatR;

namespace LifeManage.src.Application.Queries.Interface
{
	public abstract record IQuery<TResult> : QueryOption, IRequest<TResult>
	{
	}
}
