using System.ComponentModel.DataAnnotations;

namespace Sale_With_Maui.Shared.Entities
{
    public class City
    {
        public int Id { get; set; }

        [Display(Name = "Ciudad")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener minimo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        public int StateId { get; set; }

        public State State { get; set; } = null!;

        public ICollection<User>? Users { get; set; }
    }
}
