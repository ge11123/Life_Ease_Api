using LifeManage.src.Application.Enums;
using LifeManage.src.Infrastructure.BaseModels;
using LifeManage.src.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LifeManage.src.Api.Controllers
{
	[Route("api/lifeManage/[controller]")]
	[ApiController]
	public class BaseController : ControllerBase
	{
		protected IActionResult HandleResult<T>(T data)
		{
			var result = new BaseResponse<T>(data);

			return Ok(result);
		}

		protected IActionResult HandleCreationResult<T>(T data)
		{
			var result = new BaseResponse<T>(data)
			{
				Status = SystemStatusEnum.CreatedSuccess.GetEnumDescription(),
				Code = (int)SystemStatusEnum.CreatedSuccess
			};

			return Ok(result);
		}

		protected IActionResult HandleModifyResult<T>(T data)
		{
			var result = new BaseResponse<T>(data)
			{
				Status = SystemStatusEnum.ModifySuccess.GetEnumDescription(),
				Code = (int)SystemStatusEnum.ModifySuccess
			};

			return Ok(result);
		}
	}
}
