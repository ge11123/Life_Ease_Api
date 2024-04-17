namespace LifeManage.src.Infrastructure.BaseModels
{
	public class BaseResponse<TData>(TData data)
	{
		public string Code { get; set; } = "200";
		public string Status { get; set; } = "success";

		public TData Data { get; set; } = data;
	}
}
