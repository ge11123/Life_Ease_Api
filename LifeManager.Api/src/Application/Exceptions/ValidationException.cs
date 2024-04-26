using Newtonsoft.Json;

namespace LifeManage.src.Application.Exceptions
{
	public class ValidationException : Exception
	{
		public IDictionary<string, string[]> Errors { get; }

		public ValidationException() : base("One or more validation failures have occurred.")
		{
			Errors = new Dictionary<string, string[]>();
		}

		public ValidationException(IDictionary<string, string[]> errors)
			: base("One or more validation failures have occurred.")
		{
			Errors = errors;
		}

		public ValidationException(string message) : base(message)
		{
			try
			{
				Errors = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(message);
			}
			catch
			{
				Errors = new Dictionary<string, string[]>();
			}
		}

		public override string ToString()
		{
			return JsonConvert.SerializeObject(new
			{
				Message = "Validation failed",
				Errors
			});
		}
	}
}
