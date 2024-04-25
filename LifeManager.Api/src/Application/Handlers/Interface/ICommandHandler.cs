using LifeManage.src.Application.Commands.Interface;
using MediatR;

namespace LifeManage.src.Application.Handlers.Interface
{
	public interface ICommandHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : ICommand<TResult>
	{

	}
}
