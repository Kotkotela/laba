using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Entities.Models
{
    public class Student
    {
        [Column("StudentId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "student name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")] public string Name { get; set; }
        [Required(ErrorMessage = "Age is a required field.")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Position is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Position is 20 characters.")]
        public string Position { get; set; }
        [ForeignKey(nameof(ayditorya))]
        public Guid ayditoryaId { get; set; }
        public ayditorya ayditorya { get; set; }
    } 
}

