using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI_Jueves_2025I.DAL.Entities
{
    public class AuditBase
    {
        [Key]//PK
        [Required]//Significa que este campo es obligatorio
        public virtual Guid Id {  get; set; } //Esta sera el PK de todas las tablas
        public virtual DateTime CreatedDate { get; set; }//Este para guardar todo registro nuevo con su date
        public virtual DateTime ModifiedDate { get; set; }//Este para guardar todo registro que se modifico con su date

    }
}
