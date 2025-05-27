using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI_Jueves_2025I.DAL.Entities
{
    public class Country : AuditBase
    {
        [Display(Name = "País")] // Para identificar el nombre mas facil
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")] // Longitud máx
        [Required(ErrorMessage = "El campo {0} es obligatorio.")] // Campo obligatorio
        public string Name { get; set; }

        [Display(Name = "Estados/Departamentos")]
        public ICollection<State>? States { get; set; }

    }
}
