using LifeManage.src.Application.Handlers.Ledger;
using LifeManage.src.Domain.Entities;

namespace LifeManage.src.Infrastructure.Repositories.Interfaces
{
	public interface ILedgerCategoryRepository : IGenericRepository<LedgerCategory>
	{
		Task CreateLedgerCategoryAsync(CreateLedgerCategoryCommand command);
	}
}
