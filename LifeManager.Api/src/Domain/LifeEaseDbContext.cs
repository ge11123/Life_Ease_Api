using LifeManage.src.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LifeManage.src.Domain
{
	public class LifeEaseDbContext(DbContextOptions<LifeEaseDbContext> options) : DbContext(options)
	{
		public DbSet<TodoList> TodoList { get; set; }
		public DbSet<SidebarMenu> SidebarMenu { get; set; }

		public DbSet<FoodCategory> FoodCategory { get; set; }
		public DbSet<FoodItem> FoodItem { get; set; }
		
		public DbSet<LedgerCategory> LedgerCategory { get; set; }
		public DbSet<LedgerTransaction> LedgerTransaction { get; set; }
		public DbSet<LedgerUser> LedgerUser { get; set; }

		public DbSet<Region> Region { get; set; }
		public DbSet<Store> Restaurant { get; set; }
		public DbSet<StoreCategoryLink> RestaurantCategory { get; set; }
		public DbSet<StoreVisit> RestaurantVisit { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 配置表名稱
            modelBuilder.Entity<TodoList>().ToTable("TODO_LIST");
            modelBuilder.Entity<SidebarMenu>().ToTable("SIDEBAR_MENU");

            modelBuilder.Entity<FoodCategory>().ToTable("FOOD_CATEGORY");
            modelBuilder.Entity<FoodItem>().ToTable("FOOD_ITEM");
            
			modelBuilder.Entity<LedgerCategory>().ToTable("LEDGER_CATEGORIES");
			modelBuilder.Entity<LedgerTransaction>().ToTable("LEDGER_TRANSACTIONS");
			modelBuilder.Entity<LedgerUser>().ToTable("LEDGER_USERS");

			modelBuilder.Entity<Region>().ToTable("REGION");

            modelBuilder.Entity<StoreCategoryLink>().ToTable("STORE_CATEGORY_LINKS");
            modelBuilder.Entity<Store>().ToTable("STORES");
            modelBuilder.Entity<StoreVisit>().ToTable("STORE_VISITS");

		}
    }

}
