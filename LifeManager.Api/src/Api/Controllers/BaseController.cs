using LifeManage.src.Infrastructure.BaseModels;
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
	}
}
