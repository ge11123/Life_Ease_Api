using LifeManage.src.Application.Enums;
using LifeManage.src.Application.Exceptions;
using LifeManage.src.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace LifeManage.src.Application.Filter
{
	public class ExceptionFilter : ExceptionFilterAttribute
	{
		private readonly ILogger<ExceptionFilter> _logger;
		public ExceptionFilter(ILogger<ExceptionFilter> logger)
		{
			_logger = logger;
		}

		public override void OnException(ExceptionContext context)
		{
			var res = BuildExceptionResult(context.Exception).Result;
			context.HttpContext.Response.StatusCode = res.Item1;
			context.Result = res.Item2;

			base.OnException(context);
		}

		private async Task<(int, JsonResult)> BuildExceptionResult(Exception ex)
		{
			Object data = new { };

			int statusCode;
			string message;
			if (ex is ValidationException validationEx)
			{
				statusCode = (int)SystemStatusEnum.DataValidationError;
				message = SystemStatusEnum.DataValidationError.GetEnumDescription();
				var errors = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(validationEx.Message);
				data = new { Errors = errors };
			}
			else if (ex is NotFoundException)
			{
				statusCode = (int)SystemStatusEnum.NotFound; ;
				message = SystemStatusEnum.NotFound.GetEnumDescription();
			}
			else if (ex is ModifyDataException)
			{
				statusCode = (int)SystemStatusEnum.ModifyError;
				message = SystemStatusEnum.ModifyError.GetEnumDescription();
				data = new { Error = ex.Message };
			}
			else if (ex is CreatedException)
			{
				statusCode = (int)SystemStatusEnum.BadRequest;
				message = SystemStatusEnum.BadRequest.GetEnumDescription();
				data = new { Error = ex.Message };
			}
			else
			{
				statusCode = (int)SystemStatusEnum.InternalServerError;
				message = SystemStatusEnum.InternalServerError.GetEnumDescription();
				data = new { Error = ex.Message };
			}

			return (statusCode, new JsonResult(new
			{
				StatusCode = statusCode,
				ErrorMessage = message,
				Data = data
			}));


		}
	}
}
