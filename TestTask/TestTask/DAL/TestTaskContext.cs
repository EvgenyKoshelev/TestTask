using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TestTask.Models;

namespace TestTask.DAL
{
	public class TestTaskContext : DbContext
	{
		public TestTaskContext() : base("TestTaskContext")
		{
		}

		public DbSet<Store> Stores { get; set; }
		public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			modelBuilder.Entity<Store>()
				.HasMany(x => x.Products)
				.WithMany(p => p.Stores)
				.Map(t => t.MapLeftKey("StoreId")
					.MapRightKey("ProductId")
					.ToTable("StoreProduct"));
		}
	}
}