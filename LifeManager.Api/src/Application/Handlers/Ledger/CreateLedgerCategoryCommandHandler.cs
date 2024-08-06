using LifeManage.src.Application.Commands.Interface;
using LifeManage.src.Application.Handlers.Interface;
using LifeManage.src.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace LifeManage.src.Application.Handlers.Ledger
{
	/// <summary>
	/// 創建記帳分類指令
	/// </summary>
	/// <param name="Name">分類名稱</param>
	/// <param name="Type">支出or收入(expense/income)</param>
	/// <param name="Icon"></param>
	public record CreateLedgerCategoryCommand(
		string Name,
		int Type,
		string Icon
	) : ICommand<Unit>;

	public class CreateLedgerCategoryCommandHandler : ICommandHandler<CreateLedgerCategoryCommand, Unit>
	{
		private readonly ILedgerCategoryRepository _ledgerCategoryRepository;

		public CreateLedgerCategoryCommandHandler(ILedgerCategoryRepository ledgerCategoryRepository)
		{
			_ledgerCategoryRepository = ledgerCategoryRepository;
		}

		public async Task<Unit> Handle(CreateLedgerCategoryCommand command, CancellationToken cancellationToken)
		{
			await _ledgerCategoryRepository.CreateLedgerCategoryAsync(command);
			return Unit.Value;
		}
	}
}
