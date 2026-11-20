using System.ComponentModel.DataAnnotations;

namespace BoardGamesMini.Data.Entities;

public class BoardGame : IValidatableObject
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Името е задължително.")]
    [StringLength(100, ErrorMessage = "Името може да бъде до 100 символа.")]
    public string Name { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "Минималният брой играчи трябва да е положителен.")]
    public int MinPlayers { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Максималният брой играчи трябва да е положителен.")]
    public int MaxPlayers { get; set; }

    [Required(ErrorMessage = "Описанието е задължително.")]
    [StringLength(1000, ErrorMessage = "Описанието може да бъде до 1000 символа.")]
    public string Description { get; set; } = string.Empty;

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; } = null!;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (MaxPlayers < MinPlayers)
        {
            yield return new ValidationResult(
                "Максималният брой играчи не може да е по-малък от минималния.",
                new[] { nameof(MaxPlayers) });
        }
    }
}
