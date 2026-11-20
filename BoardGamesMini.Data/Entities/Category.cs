using System.ComponentModel.DataAnnotations;

namespace BoardGamesMini.Data.Entities;

public class Category
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Името на категорията е задължително.")]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [StringLength(300)]
    public string Description { get; set; } = string.Empty;

    public ICollection<BoardGame> BoardGames { get; set; } = new List<BoardGame>();
}
