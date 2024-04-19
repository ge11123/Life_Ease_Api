using MediatR;

namespace LifeManage.src.Application.Queries.Interface
{
    public interface IQuery<TResult> :  IRequest<TResult>
	{
    }
}
