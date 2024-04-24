using LifeManage.src.Application.Enums;

namespace LifeManage.src.Application.Exceptions
{
	public class MessageException : Exception
	{
		public int Status { get; set; }
		public string ClientMessage { get; set; }
		public int? HttpCode { get; set; }
		public Dictionary<string, string> ErrorIdDic { get; set; }


		public MessageException(SystemStatusEnum status, string message = "") : base(message)
		{
			this.Status = (int)status;
		}
		public MessageException(SystemStatusEnum status, Dictionary<string, string> data, string message = "") : base(message)
		{
			this.Status = (int)status;
			if (data == null) { data = new Dictionary<string, string>(); };
			this.ErrorIdDic = data;
		}

		public MessageException(string message, int status = 400) : base(message)
		{
			this.Status = status;
			this.ClientMessage = message;
			this.HttpCode = status;
		}
	}
}
