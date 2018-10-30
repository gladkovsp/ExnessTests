using System;
using System.Data.Entity;
using System.Linq;

using Exness.Models;

namespace Exness.DataRepository
{
    public class VendorRepository
	{
		VendorContext db = new VendorContext();

		public void AddVendorToDb(Vendor vendor)
        {
			db.Vendors.Add(vendor);

			db.SaveChanges();
		}

        public void CleanUpDb()
        {
			db.Categories.RemoveRange(db.Categories);
			db.Vendors.RemoveRange(db.Vendors);

			db.SaveChanges();
		}

		public Vendor GetVendorById(Guid id)
		{
			return db.Vendors.FirstOrDefault(v => v.Id == id);
		}
	}
}