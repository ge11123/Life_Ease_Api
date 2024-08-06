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
				await AddLedgerTransactionAsync(command);

				// 新增一筆商店造訪紀錄
				await AddStoreVisitAsync(command);

				// 新增 storeCategoryLink
				var exists = await _context.StoreCategoryLink
										  .AnyAsync(x => x.LedgerCategoryId == command.CategoryId &&
														 x.StoreId == command.StoreId);

				if (!exists)
				{
					await AddStoreCategoryLinkAsync(command);
				}

				await _context.SaveChangesAsync();
				await dbTransaction.CommitAsync();
			}
			catch (Exception e)
			{
				await dbTransaction.RollbackAsync();
				throw new Exception(e.Message);
			}
		}

		/// <summary>
		/// 新增一筆(支出/收入)
		/// </summary>
		/// <returns></returns>
		private async Task AddLedgerTransactionAsync(CreateLedgerCommand command)
		{
			var transaction = _mapper.Map<LedgerTransaction>(command);
			await _context.LedgerTransaction.AddAsync(transaction);
		}

		/// <summary>
		/// 新增一筆商店造訪紀錄
		/// </summary>
		/// <param name="command"></param>
		/// <returns></returns>
		private async Task AddStoreVisitAsync(CreateLedgerCommand command)
		{
			var visitInfo = _mapper.Map<StoreVisit>(command);
			await _context.StoreVisit.AddAsync(visitInfo);
		}

		private async Task AddStoreCategoryLinkAsync(CreateLedgerCommand command)
		{
			var storeCategoryLink = _mapper.Map<StoreCategoryLink>(command);
			await _context.StoreCategoryLink.AddAsync(storeCategoryLink);
		}
	}
}
