using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryAPI.Models
{
	public class Book
	{
		[Key]
		public int Id { set; get; }

		[MaxLength(128)]
		public required string Title { get; set; }

		[MaxLength(128)]
		public required string Author { get; set; }

		[MinLength(128)]
		public required  string Description { get; set; }

		public required DateTime PublishedDate { get; set; }

		public required string ContextPath { get; set; }

		public required string CoverPath { get; set; }

		public required int RatingCount { get; set; } = 0;
		public required int Rating { get; set; } = 5;

		[JsonIgnore]
		[MaxLength(128)]
		public ICollection<ReadingSession>? ReadingSessions { get; set; }

		[Column(TypeName = "VARCHAR(20)")]
		public Ganre Ganre { get; set; }
	}


	public enum Ganre
	{
		FANTASY,
		ACTION,
		MYSTERY,
		HORROR,
		HISTORICAL,
		ROMANCE,
	}

}
