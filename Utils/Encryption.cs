using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using NpDal;

namespace Utils
{
	public static class Encryption
	{
		private static readonly UTF8Encoding Encoder = new UTF8Encoding();

		public static void EncryptPassword(string password, User user)
		{
		    var rijndaelManaged = new RijndaelManaged {KeySize = 256};
		    rijndaelManaged.GenerateKey();
			rijndaelManaged.GenerateIV();

			var encryptor = rijndaelManaged.CreateEncryptor();
			var bytes = Encoder.GetBytes(password);
			var memoryStream = new MemoryStream();
			using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
			{
				cryptoStream.Write(bytes, 0, bytes.Length);
			}
			var encryptedBytes = memoryStream.ToArray();
			var base64String = Convert.ToBase64String(encryptedBytes);

			user.PasswordHash = base64String;
			user.Key = rijndaelManaged.Key;
			user.Vector = rijndaelManaged.IV;
		}
	}
}
