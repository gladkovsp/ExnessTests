using Exness.Models;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Exness.Helpers
{
	public static class JsonHelper
	{
		public static bool JsonCompare(object obj1, object obj2)
		{
			if (ReferenceEquals(obj1, obj2)) return true;
			if ((obj1 == null) || (obj2 == null)) return false;
			if (obj1.GetType() != obj2.GetType()) return false;

			var obj1Json = JsonConvert.SerializeObject(obj1);
			var obj2Json = JsonConvert.SerializeObject(obj2);

			return obj1Json == obj2Json;
		}

		public static string WriteFromObject(Vendor vendor)
		{
			MemoryStream ms = new MemoryStream();

			DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Vendor));
			ser.WriteObject(ms, vendor);
			byte[] json = ms.ToArray();
			ms.Close();
			return Encoding.UTF8.GetString(json, 0, json.Length);
		}

		public static Vendor ReadToObject(string json)
		{
			Vendor deserializedVendor = new Vendor();
			MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
			DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedVendor.GetType());
			deserializedVendor = ser.ReadObject(ms) as Vendor;
			ms.Close();
			return deserializedVendor;
		}
	}
}