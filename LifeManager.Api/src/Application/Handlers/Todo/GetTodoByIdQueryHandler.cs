using LifeManage.src.Application.Handlers.Interface;
using LifeManage.src.Application.Queries.Interface;
using LifeManage.src.Application.Queries.Todo;
using LifeManage.src.Infrastructure.Repositories.Interfaces;

namespace LifeManage.src.Application.Handlers.Todo
{
    public record GetTodoByIdQuery(int Id) : IQuery<GetTodoByIdResponse>;

    public class GetTodoByIdQueryHandler : IQueryHandler<GetTodoByIdQuery, GetTodoByIdResponse>
    {
        private readonly ITodoRepository _todoRepository;

        public GetTodoByIdQueryHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<GetTodoByIdResponse> Handle(GetTodoByIdQuery query, CancellationToken cancellationToken)
        {
            var res = await _todoRepository.FirstOrDefaultAsync<GetTodoByIdResponse>(x => x.Id == query.Id);

            return res;
        }
    }
}
