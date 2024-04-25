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

		[EnumStatusCode(HttpStatusCode.OK)]
		[Description("Created Sucess")]
		Created = 201,

		[EnumStatusCode(HttpStatusCode.BadRequest)]
		[Description("Data Validation Failed")]
		DataValidationError = 422,

		[EnumStatusCode(HttpStatusCode.InternalServerError)]
		[Description("Internal Server is Error")]
		InternalServerError = 500,
	}
}
