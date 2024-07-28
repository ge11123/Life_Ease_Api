using LifeManage.src.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LifeManage.src.Domain
{
	public class LifeEaseDbContext(DbContextOptions<LifeEaseDbContext> options) : DbContext(options)
	{
		public DbSet<TodoList> TodoList { get; set; }
		public DbSet<SidebarMenu> SidebarMenu { get; set; }

		public DbSet<Region> Region { get; set; }
		public DbSet<Restaurant> Restaurant { get; set; }
		public DbSet<RestaurantCategory> RestaurantCategory { get; set; }
		public DbSet<RestaurantVisit> RestaurantVisit { get; set; }
		public DbSet<FoodCategory> FoodCategory { get; set; }
		public DbSet<FoodItem> FoodItem { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 配置表名稱
            modelBuilder.Entity<TodoList>().ToTable("TODO_LIST");
            modelBuilder.Entity<SidebarMenu>().ToTable("SIDEBAR_MENU");

            modelBuilder.Entity<Region>().ToTable("REGION");
            modelBuilder.Entity<Restaurant>().ToTable("RESTAURANT");
            modelBuilder.Entity<RestaurantCategory>().ToTable("RESTAURANT_CATEGORY");
            modelBuilder.Entity<RestaurantVisit>().ToTable("RESTAURANT_VISIT");
            modelBuilder.Entity<FoodCategory>().ToTable("FOOD_CATEGORY");
            modelBuilder.Entity<FoodItem>().ToTable("FOOD_ITEM");
		}
    }

}
