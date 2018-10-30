using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Exness.Models
{
	[DataContract]
	public class Category
	{
		[DataMember(Name = "id", Order = 1)]
		public Guid Id { get; set; }

		[DataMember(Name = "name", Order = 2)]
		public string Name { get; set; }

		[JsonIgnore]
		public Guid? VendorId { get; set; }

		[JsonIgnore]
		public virtual Vendor Vendor { get; set; }

		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			if (obj == this) return true;
			var category = obj as Category;
			return category != null && Equals(category);
		}

		protected bool Equals(Category category)
		{
			return Id.Equals(category.Id)
				   && Name.Equals(category.Name);
		}

	}
}