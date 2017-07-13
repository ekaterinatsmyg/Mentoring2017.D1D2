namespace EFSamples.Model
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class NorthwindDB : DbContext
	{
		public NorthwindDB()
			: base("name=Northwind")
		{
		}

		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			var category = modelBuilder.Entity<Category>()
				.ToTable("Northwind.Categories")
				.HasKey(c => c.Id);

			category.Property(c => c.Id).HasColumnName("CategoryID")
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			category.Property(c => c.Name).HasColumnName("CategoryName").IsRequired().HasMaxLength(15);
			category.Property(c => c.Description).HasColumnType("ntext");
			category.Property(c => c.Picture).HasColumnType("image");
			category.HasMany(c => c.Products).WithRequired(p => p.Category);

			var product = modelBuilder.Entity<Product>()
				.ToTable("Northwind.Products")
				.HasKey(p => p.Id);

			product.Property(p => p.Id).HasColumnName("ProductID")
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
			product.Property(p => p.Name).HasColumnName("ProductName").IsRequired().HasMaxLength(40);
			product.Property(p => p.QuantityPerUnit).HasMaxLength(20);
			product.Property(p => p.UnitPrice).HasColumnType("money").HasPrecision(19, 4); ;
			product.HasRequired(p => p.Category).WithMany(c => c.Products).Map(p => p.MapKey("CategoryID"));
				
		}
	}
}
