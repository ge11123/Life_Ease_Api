using System.Net;

namespace LifeManage.src.Infrastructure.Attributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
	public class EnumStatusCodeAttribute : Attribute
	{
		public HttpStatusCode HttpStatusCode { get; set; }
		public EnumStatusCodeAttribute(HttpStatusCode httpStatusCode)
		{
			HttpStatusCode = httpStatusCode;
		}
	}
}
