using System.Data.Entity;

using Exness.Models;

namespace Exness.DataRepository
{
	public class VendorContext : DbContext
	{
		public VendorContext() : base("DefaultConnection")
		{
		}

		public DbSet<Vendor> Vendors { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
}