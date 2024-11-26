using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }

		[Required, MaxLength(64), MinLength(3)]
		public required string Name { get; set; }

		[Required, MaxLength(128)]
		public required string Email { get; set; }

		[Required, MaxLength(128), MinLength(8)]
		public required string Password { get; set; }

		public ICollection<ReadingSession>? ReadingSessions { get; set; }

		[Required]
		public required Statistic Statistic { get; set; }
	}
}
