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
			modelBuilder.Entity<FoodCategory>(entity =>
			{
				entity.ToTable("FOOD_CATEGORY");
				entity.HasNoKey();

				entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");
				entity.Property(e => e.CategoryName).HasColumnName("CATEGORY_NAME");

				// 如果有其他屬性或配置，繼續在這裡添加
			});

			modelBuilder.Entity<FoodItem>(entity =>
			{
				entity.ToTable("FOOD_ITEM");

				entity.HasKey(e => e.FoodItemId);

				entity.Property(e => e.FoodItemId).HasColumnName("FOOD_ITEM_ID");
				entity.Property(e => e.VisitId).HasColumnName("VISIT_ID");
				entity.Property(e => e.FoodName).HasColumnName("FOOD_NAME");
				entity.Property(e => e.FoodCategoryId).HasColumnName("FOOD_CATEGORY_ID");
				entity.Property(e => e.Cost).HasColumnName("COST");

				// 如果有其他屬性或配置，繼續在這裡添加
			});

			// 記帳
			modelBuilder.Entity<LedgerCategory>(entity =>
			{
				entity.ToTable("LEDGER_CATEGORIES");

				entity.HasNoKey();

				entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");
				entity.Property(e => e.UserId).HasColumnName("USER_ID");
				entity.Property(e => e.Name).HasColumnName("NAME");
				entity.Property(e => e.Type).HasColumnName("TYPE");
				entity.Property(e => e.Icon).HasColumnName("ICON");
			});

			modelBuilder.Entity<LedgerTransaction>(entity =>
			{
				entity.ToTable("LEDGER_TRANSACTIONS");

				entity.HasKey(e => e.TransactionId);

				entity.Property(e => e.TransactionId).HasColumnName("TRANSACTION_ID");
				entity.Property(e => e.UserId).HasColumnName("USER_ID");
				entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");
				entity.Property(e => e.Amount).HasColumnName("AMOUNT");
				entity.Property(e => e.Note).HasColumnName("NOTE");
				entity.Property(e => e.TransactionDate).HasColumnName("TRANSACTION_DATE");
				entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");
				entity.Property(e => e.UpdatedAt).HasColumnName("UPDATED_AT");
			});

			modelBuilder.Entity<LedgerUser>(entity =>
			{
				entity.ToTable("LEDGER_USERS");

				entity.HasKey(e => e.UserId);

				entity.Property(e => e.UserId).HasColumnName("USER_ID");
				entity.Property(e => e.UserName).HasColumnName("USER_NAME");
				entity.Property(e => e.Email).HasColumnName("EMAIL");
				entity.Property(e => e.AuthToken).HasColumnName("AUTH_TOKEN");
				entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");
				entity.Property(e => e.UpdatedAt).HasColumnName("UPDATED_AT");
			});

			// 地區
			modelBuilder.Entity<Region>(entity =>
			{
				entity.ToTable("REGION");

				entity.HasKey(e => e.RegionId);

				entity.Property(e => e.RegionId).HasColumnName("REGION_ID");
				entity.Property(e => e.CountyName).HasColumnName("COUNTY_NAME");
				entity.Property(e => e.TownshipName).HasColumnName("TOWNSHIP_NAME");
			});

			// 商店
			modelBuilder.Entity<StoreCategoryLink>(entity =>
			{
				entity.ToTable("STORE_CATEGORY_LINKS");
				entity.HasKey(e => new { e.StoreId, e.LedgerCategoryId });

				entity.Property(e => e.StoreId).HasColumnName("STORE_ID");
				entity.Property(e => e.LedgerCategoryId).HasColumnName("LEDGER_CATEGORY_ID");
			});

			modelBuilder.Entity<Store>(entity =>
			{
				entity.ToTable("STORES");

				entity.HasKey(e => e.StoreId);

				entity.Property(e => e.StoreId).HasColumnName("STORE_ID");
				entity.Property(e => e.Name).HasColumnName("NAME");
				entity.Property(e => e.Address).HasColumnName("ADDRESS");
				entity.Property(e => e.Latitude).HasColumnName("LATITUDE");
				entity.Property(e => e.Longitude).HasColumnName("LONGITUDE");
				entity.Property(e => e.RegionId).HasColumnName("REGION_ID");
			});

			modelBuilder.Entity<StoreVisit>(entity =>
			{
				entity.ToTable("STORE_VISITS");

				entity.HasKey(e => e.StoreVisitId);

				entity.Property(e => e.StoreVisitId).HasColumnName("STORE_VISIT_ID");
				entity.Property(e => e.StoreId).HasColumnName("STORE_ID");
				entity.Property(e => e.VisitedDate).HasColumnName("VISITED＿DATE");
				entity.Property(e => e.UserId).HasColumnName("USER_ID");
			});

		}
    }

}
