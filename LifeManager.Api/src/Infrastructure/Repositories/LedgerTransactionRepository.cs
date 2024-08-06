using AutoMapper;
using LifeManage.src.Application.Handlers.Ledger;
using LifeManage.src.Domain;
using LifeManage.src.Domain.Entities;
using LifeManage.src.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LifeManage.src.Infrastructure.Repositories
{
	public class LedgerTransactionRepository : LifeManageRepository<LedgerTransaction>, ILedgerTransactionRepository
	{
		private readonly LifeEaseDbContext _context;
		private readonly IMapper _mapper;

		public LedgerTransactionRepository(LifeEaseDbContext context, IMapper mapper, ClaimsPrincipal clams) : base(context, mapper, clams)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task CreateLedgerTransaction(CreateLedgerCommand command)
		{
			var dbTransaction = await _context.Database.BeginTransactionAsync();
			try
			{
				// 新增一筆(支出/收入)
				var transaction = _mapper.Map<LedgerTransaction>(command);
				await InsertAsync(transaction);

				// 新增一筆商店造訪紀錄
				var visitInfo = _mapper.Map<StoreVisit>(command);
				await _context.StoreVisit.AddAsync(visitInfo);
				await _context.SaveChangesAsync();

				await dbTransaction.CommitAsync();
			}
			catch (Exception)
			{
				await dbTransaction.RollbackAsync();
				throw new Exception();
			}
		}
	}
}
