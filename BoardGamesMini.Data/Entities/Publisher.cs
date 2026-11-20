using System.ComponentModel.DataAnnotations;

namespace BoardGamesMini.Data.Entities;

public class Publisher
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Името на издателя е задължително.")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(60)]
    public string Country { get; set; } = string.Empty;

    [StringLength(200)]
    public string Website { get; set; } = string.Empty;

    public ICollection<BoardGame> BoardGames { get; set; } = new List<BoardGame>();
}
