using LifeManage.src.Infrastructure.Attributes;
using System.ComponentModel;
using System.Net;

namespace LifeManage.src.Application.Enums
{
	public enum LedgerEnum
	{
		[Description("收入")]
		Income = 0,

		[Description("支出")]
		Expense = 1,
	}
}
