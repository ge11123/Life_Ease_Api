using Microsoft.AspNetCore.Identity;

namespace IdentityManage.src.Domain.Entities
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
	}
}
