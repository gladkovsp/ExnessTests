using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Exness.Models
{
	[DataContract]
	public class Vendor
	{
		[DataMember(Name = "id", Order = 1)]
		public Guid Id { get; set; }

		[DataMember(Name = "name", Order = 2)]
		public string Name { get; set; }

		[DataMember(Name = "rating", Order = 3)]
		public int Rating { get; set; }

		[DataMember(Name = "categories", Order = 4)]
		public  virtual ICollection<Category> Categories { get; set; }
		
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
				   && Rating.Equals(vendor.Rating);
		}
	}
}
