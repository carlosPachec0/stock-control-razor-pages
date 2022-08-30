using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal_2.Models
{
    public class Productos
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El código del producto es requerido."), Display(Name = "Código")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre del producto es requerido."), Display(Name = "Nombre del producto")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La cantidad es requerida en números enteros."), RegularExpression(@"^\d+$")]
        public int Cantidad { get; set; }

        public bool Auditado { get; set; }

        [DataType(DataType.Date), Display(Name = "Fecha de control")]
        public DateTime? FechaControl { get; set; }
    }
}
