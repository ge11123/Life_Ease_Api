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

		[EnumStatusCode(HttpStatusCode.Created)]
		[Description("Created Sucess")]
		CreatedSuccess = 201,

		[EnumStatusCode(HttpStatusCode.NoContent)]
		[Description("Modify Sucess")]
		ModifySuccess = 204,

		[EnumStatusCode(HttpStatusCode.BadRequest)]
		[Description("Data Validation Failed")]
		DataValidationError = 422,

		[EnumStatusCode(HttpStatusCode.NotFound)]
		[Description("ModifyError")]
		ModifyError = 460,

		[EnumStatusCode(HttpStatusCode.NotFound)]
		[Description("NotFound")]
		NotFound = 404,

		[EnumStatusCode(HttpStatusCode.InternalServerError)]
		[Description("Internal Server is Error")]
		InternalServerError = 500,
	}
}
