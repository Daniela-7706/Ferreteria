using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Ferreteria.Models
{
    public class Factura
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Código Factura")]
        public string CodFactura { get; set; }

        [Required]
        [StringLength(40)]
        public string Cliente { get; set; }


        [Required(ErrorMessage = "La fecha de la factura es obligatoria")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DisplayName("Fecha de la Factura")]
        public string FechaFactura { get; set; }


        public List<Detalle_Factura> Detalles { get; set; } = new List<Detalle_Factura>();


        [DisplayName("Total de la Factura")]
        public decimal Totalfactura
        {

            get
            {
                decimal total = 0;
                foreach (var detalle in Detalles)
                {
                    total += detalle.CantidadP * detalle.PrecioUnitario;
                }
                return total;

            }
        }

        [Required]
        [DisplayName("Empleado")]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
