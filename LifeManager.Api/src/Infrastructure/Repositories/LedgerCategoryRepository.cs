using AutoMapper;
using LifeManage.src.Application.Exceptions;
using LifeManage.src.Application.Handlers.Ledger;
using LifeManage.src.Domain;
using LifeManage.src.Domain.Entities;
using LifeManage.src.Infrastructure.Repositories.Interfaces;
using System.Security.Claims;

namespace LifeManage.src.Infrastructure.Repositories
{
	public class LedgerCategoryRepository : LifeManageRepository<LedgerCategory>, ILedgerCategoryRepository
	{
		private readonly LifeEaseDbContext _context;
		private readonly IMapper _mapper;

		public LedgerCategoryRepository(LifeEaseDbContext context, IMapper mapper, ClaimsPrincipal clams) : base(context, mapper, clams)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task CreateLedgerCategoryAsync(CreateLedgerCategoryCommand command)
		{
			try
			{
				var ledgerCategory = _mapper.Map<LedgerCategory>(command);
				await _context.LedgerCategory.AddAsync(ledgerCategory);

				await _context.SaveChangesAsync();
			}
			catch (Exception e)
			{
				throw new CreatedException(e.Message);
			}
		}
	}
}
