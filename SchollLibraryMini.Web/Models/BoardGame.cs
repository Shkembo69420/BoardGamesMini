
using System.ComponentModel.DataAnnotations;

namespace SchollLibraryMini.Web.Models
{
    public class BoardGame
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Името е задължително.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Категорията е задължителна.")]
        public string Category { get; set; } = string.Empty;

        [Range(1, int.MaxValue,
            ErrorMessage = "Минималният брой играчи трябва да е положителен.")]
        public int MinPlayers { get; set; }

        [Range(1, int.MaxValue,
            ErrorMessage = "Максималният брой играчи трябва да е положителен.")]
        public int MaxPlayers { get; set; }

        [Required(ErrorMessage = "Описанието е задължително.")]
        public string Description { get; set; } = string.Empty;
    }
}
