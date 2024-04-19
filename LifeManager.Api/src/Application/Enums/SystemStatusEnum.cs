using LifeManage.src.Infrastructure.Attributes;
using System.ComponentModel;
using System.Net;

namespace LifeManage.src.Application.Enums
{
	public enum SystemStatusEnum
	{
		[EnumStatusCode(HttpStatusCode.OK)]
		[Description("Sucess")]
		Success = 200,
		
	}
}
