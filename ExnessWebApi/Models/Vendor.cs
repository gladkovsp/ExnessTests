using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using Newtonsoft.Json;

namespace Exness.Models
{
	public class Vendor
	{
		[Required]
		[JsonProperty("id", Order = 1)]
		public Guid Id { get; set; }

		[Required]
		[JsonProperty("name", Order = 2)]
		public string Name { get; set; }

		[Required]
		[JsonProperty("rating", Order = 3)]
		public int Rating { get; set; } 

		[JsonProperty("categories", Order = 4)]
		public  virtual ICollection<Category> Categories { get; set; }

		public Vendor()
		{
			Categories = new List<Category>();
		}

		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (obj == this) return true;
			var vendor = obj as Vendor;
			return vendor != null && Equals(vendor);
		}

		protected bool Equals(Vendor vendor)
		{
			return Id.Equals(vendor.Id)
				   && Name.Equals(vendor.Name)
				   && Rating.Equals(vendor.Rating)
				   && !Categories.Except(vendor.Categories).Any();
		}


	}
}
