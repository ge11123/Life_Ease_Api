using LifeManage.src.Application.Queries.Todo;
using MediatR;

namespace LifeManage.src.Application.Handlers
{
	public class TodoCommandHandler : IRequestHandler<GetTodoRequest, GetTodoResponse>
	{
		public async Task<GetTodoResponse> Handle(GetTodoRequest request, CancellationToken cancellationToken)
		{
			return new GetTodoResponse()
			{
				Name = "Jason"
			};
		}
	}
}
