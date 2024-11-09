using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
	public class ReadingSession
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public DateTime StartTime { get; set; }

		public DateTime? EndTime { get; set; }

		[Required]
		public required User User { get; set; }

		[Required]
		public int UserId { get; set; }

		[Required]
		public required Book Book { get; set; }

		[Required]
		public int BookId { get; set; }

		[Column(TypeName = "varchar(20)")]
		public Status Status { get; set; }

	}


	public enum Status
	{
		READING,
		FINISHED,
	}
}
