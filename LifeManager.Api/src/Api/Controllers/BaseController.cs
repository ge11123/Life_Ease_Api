using LifeManage.src.Application.Enums;
using LifeManage.src.Infrastructure.BaseModels;
using LifeManage.src.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;

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
				Status = SystemStatusEnum.Created.GetEnumDescription(),
				Code = (int)SystemStatusEnum.Created
			};

			return Ok(result);
		}
	}
}
