using LifeManage.src.Application.Handlers.Ledger;
using LifeManage.src.Domain.Entities;

namespace LifeManage.src.Infrastructure.Repositories.Interfaces
{
	public interface ILedgerTransactionRepository : IGenericRepository<LedgerTransaction>
	{
		Task CreateLedgerTransaction(CreateLedgerCommand command);
	}
}
