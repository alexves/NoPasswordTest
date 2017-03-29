using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NpDal
{
	public class User
	{
		[Key]
		public int Id { get; set; }

		[Index(IsUnique = true)]
		[StringLength(50)]
		public string Username { get; set; }

		public string PasswordHash { get; set; }

		public byte[] Key { get; set; }
		public byte[] Vector { get; set; }
	}
}
