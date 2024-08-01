using AutoMapper;
using LifeManage.src.Domain;
using LifeManage.src.Domain.Entities;
using LifeManage.src.Infrastructure.Repositories.Interfaces;
using System.Security.Claims;

namespace LifeManage.src.Infrastructure.Repositories
{
	public class RestaurantRepository : LifeManageRepository<Restaurants>, IRestaurantRepository
	{
		private readonly LifeEaseDbContext _context;
		public RestaurantRepository(LifeEaseDbContext context, IMapper mapper, ClaimsPrincipal clams) : base(context, mapper, clams)
		{
			_context = context;
		}
	}
}
