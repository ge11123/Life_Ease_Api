using LifeManage.src.Application.Handlers.Ledger;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LifeManage.src.Api.Controllers
{
	public class LedgerController : BaseController
	{
		private readonly IMediator _mediator;

		public LedgerController(IMediator mediator)
		{
			_mediator = mediator;
		}

		/// <summary>
		/// 新增記帳
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> CreateLedger([FromBody] CreateLedgerCommand command)
		{
			return HandleCreationResult(await _mediator.Send(command));
		}

		/// <summary>
		/// 新增記帳分類
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		[Route("category")]
		public async Task<IActionResult> CreateLedgerCategory([FromBody] CreateLedgerCategoryCommand command)
		{
			return HandleCreationResult(await _mediator.Send(command));
		}

		///// <summary>
		///// 取得紀錄
		///// </summary>
		///// <returns></returns>
		//[HttpGet]
		//public async Task<IActionResult> GetLedger()
		//{
		//	return HandleResult(await _mediator.Send(null));
		//}

		///// <summary>
		///// 修改帳額
		///// </summary>
		///// <returns></returns>
		//[Route("{transactionId}")]
		//[HttpPut]
		//public async Task<IActionResult> UpdateLedger([FromRoute] string transactionId)
		//{
		//	return HandleResult(await _mediator.Send(null));
		//}

		///// <summary>
		///// 刪除帳額
		///// </summary>
		///// <returns></returns>
		//[Route("{transactionId}")]
		//[HttpDelete]
		//public async Task<IActionResult> DeleteLedger([FromRoute] string transactionId)
		//{
		//	return HandleResult(await _mediator.Send(null));
		//}
	}
}
