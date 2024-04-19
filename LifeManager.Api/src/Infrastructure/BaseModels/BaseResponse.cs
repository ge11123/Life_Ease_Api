using LifeManage.src.Application.Enums;
using LifeManage.src.Infrastructure.Extensions;

namespace LifeManage.src.Infrastructure.BaseModels
{
	public class BaseResponse<TData>
	{
		public int Code { get; set; } = (int)SystemStatusEnum.Success;
		public string Status { get; set; } = SystemStatusEnum.Success.GetEnumDescription();
		public TData Data { get; set; }

		public BaseResponse(TData data)
		{
			Data = data;
		}

	}
}
