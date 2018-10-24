using Newtonsoft.Json;

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
	}
}