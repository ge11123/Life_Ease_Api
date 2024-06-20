using LifeManage.src.Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace LifeManage.src.Domain
{
	public class LifeEaseDbContext(DbContextOptions<LifeEaseDbContext> options) : DbContext(options)
	{
		public DbSet<TodoList> TodoList { get; set; }
		public DbSet<SidebarMenu> SidebarMenu { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 配置表名稱
            modelBuilder.Entity<TodoList>().ToTable("TODO_LIST");
            modelBuilder.Entity<SidebarMenu>().ToTable("SIDEBAR_MENU");
        }
    }

}
