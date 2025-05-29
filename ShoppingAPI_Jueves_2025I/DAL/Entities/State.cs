using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShoppingAPI_Jueves_2025I.DAL.Entities
{
    public class State : AuditBase
    {
        [Display(Name = "Estado/Departamento")] // Para identificar el nombre mas facil
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")] // Longitud máx
        [Required(ErrorMessage = "El campo {0} es obligatorio.")] // Campo obligatorio
        public string Name { get; set; }

        // Así es como relaciono 2 tablas con EF Core:
        [Display(Name = "País")]
        [JsonIgnore] // Se aplica el [JsonIgnore] Dado que se estaba generando una serializacion ciclica
                     // lo que arrojaba un error 500 al ejecutar el traer estados por Id de país
                     // esto afecta que no arroje el nombre del país del cual se estan trayendo los estados.
        public Country? Country { get; set; }

        // FK
        [Display(Name = "Id País")]
        public Guid CountryId { get; set; }

    }
}
