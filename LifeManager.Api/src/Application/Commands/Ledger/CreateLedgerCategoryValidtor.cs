using FluentValidation;
using LifeManage.src.Application.Enums;
using LifeManage.src.Application.Handlers.Ledger;

namespace LifeManage.src.Application.Commands.Ledger
{
	public class CreateLedgerCategoryValidtor : AbstractValidator<CreateLedgerCategoryCommand>
	{
		public CreateLedgerCategoryValidtor()
		{
			RuleFor(x => x.Type)
				.Must(type => Enum.IsDefined(typeof(LedgerEnum), type))
				.WithMessage("type 應為 expense 或 income");
		}
	}
}
