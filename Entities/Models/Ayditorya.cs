using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Entities.Models
{
    public class Ayditorya
    {
        [Column("AyditoryaId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "ayditorya name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Name { get; set; }
        public ICollection<student> students { get; set; }

    }
}
