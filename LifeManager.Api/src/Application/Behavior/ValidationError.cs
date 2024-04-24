namespace LifeManage.src.Application.Behavior
{
	public class ValidationError
	{

		public Object ModelErrors { get; set; }

		public ValidationError(string message) { }

		public ValidationError(Object error, string message = "")
		{
			this.ModelErrors = error;
		}
	}

}
