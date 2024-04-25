using MediatR;

namespace LifeManage.src.Application.Commands.Interface
{
	public abstract record ICommand<TResult> : IRequest<TResult>
	{
	}
}
