using System.ComponentModel.DataAnnotations;

namespace Sale_With_Maui.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }

        [Display(Name = "Pais")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener mas de {1} caractéres.")]
        public string Name { get; set; } = null!;
    }
}
