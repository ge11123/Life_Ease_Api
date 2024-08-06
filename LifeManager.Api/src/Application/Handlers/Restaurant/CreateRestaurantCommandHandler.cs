using AutoMapper;
using LifeManage.src.Application.Commands.Interface;
using LifeManage.src.Application.Handlers.Interface;
using LifeManage.src.Domain;
using LifeManage.src.Domain.Entities;
using MediatR;

namespace LifeManage.src.Application.Handlers.Restaurant
{
	/// <summary>
	/// 用於創建新餐廳的命令。
	/// </summary>
	/// <param name="RegionId">餐廳所在區域的 ID。</param>
	/// <param name="RestaurantName">餐廳名稱。</param>
	/// <param name="Latitude">餐廳位置的緯度座標。</param>
	/// <param name="Longtitude">餐廳位置的經度座標。</param>
	/// <param name="Address">餐廳的實際地址。</param>
	/// <param name="CategoryName">餐廳的類別名稱。</param>
	public record CreateRestaurantCommand(
		int RegionId,
		string RestaurantName,
		float Latitude,
		float Longtitude,
		string Address,
		string CategoryName
	) : ICommand<Unit>;

	public class CreateRestaurantCommandHandler : ICommandHandler<CreateRestaurantCommand, Unit>
	{
		private readonly IMapper _mapper;
		private readonly LifeEaseDbContext _context;

		public CreateRestaurantCommandHandler(IMapper mapper, LifeEaseDbContext context)
		{
			_mapper = mapper;
			_context = context;
		}

		public async Task<Unit> Handle(CreateRestaurantCommand command, CancellationToken cancellationToken)
		{
			var restaurant = _mapper.Map<Store>(command);
			var restaurantCategory = _mapper.Map<StoreCategoryLink>(command);

			// 新增餐廳名單
			await _context.Store.AddAsync(restaurant);

			// 新增餐廳有的食物分類
			await _context.StoreCategoryLink.AddAsync(restaurantCategory);


			await _context.SaveChangesAsync();
			return Unit.Value;
		}
	}
}
