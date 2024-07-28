using AutoMapper;
using LifeManage.src.Application.Commands.Interface;
using LifeManage.src.Application.Handlers.Interface;
using MediatR;

namespace LifeManage.src.Application.Handlers.Restaurant
{
	public record CreateRestaurantCommand() : ICommand<Unit>;

	public class CreateRestaurantCommandHandler : ICommandHandler<CreateRestaurantCommand, Unit>
	{
		private readonly IMapper _mapper;

		public CreateRestaurantCommandHandler(IMapper mapper)
		{
			_mapper = mapper;
		}

		public async Task<Unit> Handle(CreateRestaurantCommand command, CancellationToken cancellationToken)
		{

			return Unit.Value;
		}
	}
}
