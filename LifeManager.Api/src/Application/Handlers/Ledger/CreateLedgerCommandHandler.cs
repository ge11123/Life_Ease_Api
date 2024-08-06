using LifeManage.src.Application.Commands.Interface;
using LifeManage.src.Application.Handlers.Interface;
using LifeManage.src.Domain.Entities;
using LifeManage.src.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace LifeManage.src.Application.Handlers.Ledger
{
	/// <summary>
	/// 創建記帳資料的命令
	/// </summary>
	/// <param name="CategoryId">支出/收入(類別)</param>
	/// <param name="StoreId">商店Id</param>
	/// <param name="Amount">金額</param>
	/// <param name="Note">備註</param>
	/// <param name="TransactionDate">支出/收入(金額)</param>
	/// <param name="TimePeriod">時段</param>
	public record CreateLedgerCommand(

		int CategoryId,
		int StoreId,
		int Amount,
		string Note,
		DateTime TransactionDate,
		DateTime VisitedDate,
		string TimePeriod
	) : ICommand<Unit>;

	public class CreateLedgerCommandHandler : ICommandHandler<CreateLedgerCommand, Unit>
	{
		private readonly ILedgerTransactionRepository _ledgerTransactionRepository;
		private readonly IStoreRepository _storeRepository;

		public CreateLedgerCommandHandler(ILedgerTransactionRepository ledgerTransactionRepository, IStoreRepository storeRepository)
		{
			_ledgerTransactionRepository = ledgerTransactionRepository;
			_storeRepository = storeRepository;
		}

		public async Task<Unit> Handle(CreateLedgerCommand command, CancellationToken cancellationToken)
		{
			// 驗證
			_ = await _ledgerTransactionRepository
				.FirstOrDefaultAsync<LedgerTransaction>(x => x.CategoryId == command.CategoryId)
				?? throw new Exception("沒有符合的 category");

			_ = await _storeRepository
				.FirstOrDefaultAsync<Store>(x => x.StoreId == command.StoreId)
				?? throw new Exception("沒有符合的 store");

			// 新增資料
			await _ledgerTransactionRepository.CreateLedgerTransaction(command);

			return Unit.Value;
		}



	}
}
