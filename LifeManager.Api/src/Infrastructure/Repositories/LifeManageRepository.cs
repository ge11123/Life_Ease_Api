using AutoMapper;
using LifeManage.src.Domain;
using LifeManage.src.Domain.entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LifeManage.src.Infrastructure.Repositories
{
	public class LifeManageRepository<TEntity> : BaseRepository<TEntity> where TEntity : class
	{
		public LifeManageRepository(LifeEaseDbContext context) : base(context)
		{
		}

		public LifeManageRepository(LifeEaseDbContext context, IMapper mapper) : base(context, mapper)
		{
		}

		public LifeManageRepository(LifeEaseDbContext context, IMapper mapper, ClaimsPrincipal clams) : base(context, mapper, clams)
		{
		}
	}
}
