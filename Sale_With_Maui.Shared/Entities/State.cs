using System.ComponentModel.DataAnnotations;

namespace Sale_With_Maui.Shared.Entities
{
    public class State
    {
        public int Id { get; set; }

        [Display(Name = "Estado/Departamento")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener minimo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        public int CountryId { get; set; }

        public Country? Country { get; set; }

        public ICollection<City>? Cities { get; set; }

        [Display(Name = "Ciudades")]
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;
    }
}
