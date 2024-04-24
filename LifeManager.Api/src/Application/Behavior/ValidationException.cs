using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using System.Runtime.Serialization;

namespace LifeManage.src.Application.Behavior
{
	public class ValidationException : Exception
	{
		public IDictionary<string, string[]> Errors { get; }

		public ValidationException() : base("One or more validation failures have occurred.")
		{
			this.Errors = new Dictionary<string, string[]>();
		}

		public ValidationException(IDictionary<string, string[]> errors)
			: base("One or more validation failures have occurred.")
		{
			this.Errors = errors;
		}

		public ValidationException(string message) : base(message)
		{
			try
			{
				this.Errors = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(message);
			}
			catch
			{
				this.Errors = new Dictionary<string, string[]>();
			}
		}

		public override string ToString()
		{
			return JsonConvert.SerializeObject(new
			{
				Message = "Validation failed",
				Errors = this.Errors
			});
		}
	}
}
