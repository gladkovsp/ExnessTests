using System;
using System.Security.Cryptography;

namespace Exness.Helpers
{
	public class DataGenerator
	{
		public static string RandomString(int size = 10)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			var bytes = new byte[size];
			var provider = new RNGCryptoServiceProvider();
			provider.GetBytes(bytes);

			var characters = new char[size];

			for (int i = 0; i < size; i++)
			{
				characters[i] = chars[bytes[i] % chars.Length];
			}

			return new string(characters);
		}

		public static int RandomInt(int size = 20)
		{
				return new Random().Next(0, size);
		}

		public static Guid GetGuid()
		{
			return Guid.NewGuid();
		}
	}
}