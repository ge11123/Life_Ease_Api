using LifeManage.src.Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace LifeManage.src.Domain
{
	public class LifeEaseDbContext(DbContextOptions<LifeEaseDbContext> options) : DbContext(options)
	{
		public DbSet<TodoList> TodoList { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		}
	}

}
