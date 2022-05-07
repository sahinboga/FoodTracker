using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes.EntityFramework
{
	public class FoodTrackerContext:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=FoodTracker;Trusted_Connection=true");
		}

		public DbSet<Restaurant> Restaurants { get; set; }
		public DbSet<RestaurantImage> RestaurantImages { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<County> Counties { get; set; }
	}
}
