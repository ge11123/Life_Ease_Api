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
		public DbSet<Store> Store { get; set; }
		public DbSet<StoreCategoryLink> StoreCategoryLink { get; set; }
		public DbSet<StoreVisit> StoreVisit { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 配置表名稱
			// 代辦事項
            modelBuilder.Entity<TodoList>()
				.ToTable("TODO_LIST")
				.HasKey(x => x.Id);

			// SideBar
            modelBuilder.Entity<SidebarMenu>()
				.ToTable("SIDEBAR_MENU")
				.HasKey(x => x.Id);

			// 食品
            modelBuilder.Entity<FoodCategory>()
				.ToTable("FOOD_CATEGORY")
				.HasNoKey();

            modelBuilder.Entity<FoodItem>()
				.ToTable("FOOD_ITEM")
				.HasKey(x => x.FoodItemId);
            
			// 記帳
			modelBuilder.Entity<LedgerCategory>()
				.ToTable("LEDGER_CATEGORIES")
				.HasNoKey();

			modelBuilder.Entity<LedgerTransaction>()
				.ToTable("LEDGER_TRANSACTIONS")
				.HasKey(x => x.TransactionId);

			modelBuilder.Entity<LedgerUser>()
				.ToTable("LEDGER_USERS")
				.HasKey(x => x.UserId);

			// 地區
			modelBuilder.Entity<Region>()
				.ToTable("REGION")
				.HasKey(x => x.RegionId);

			// 商店
            modelBuilder.Entity<StoreCategoryLink>()
				.ToTable("STORE_CATEGORY_LINKS")
				.HasNoKey();

			modelBuilder.Entity<Store>()
				.ToTable("STORES")
				.HasKey(x => x.StoreId);

            modelBuilder.Entity<StoreVisit>()
				.ToTable("STORE_VISITS")
				.HasKey(x => x.StoreVisitId);

		}
    }

}
