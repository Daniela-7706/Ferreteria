using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Ferreteria.Models
{
    public class Detalle_Factura
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Código")]
        public int CodDetalleFactura { get; set; }

        
        [DisplayName("Factura")]
        public int FacturaId { get; set; }

        [Required]
        [DisplayName("Código Producto")]
        public int ProductoId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [DisplayName("Cantidad de Producto")]
        public int CantidadP { get; set; }

        [DisplayName("Producto")]
        public string NombreProducto { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        [DataType(DataType.Currency)]
        [DisplayName("Precio Unitario")]
        public decimal PrecioUnitario { get; set; }

        [DisplayName("Subtotal")]
        public decimal TotalDetalle { get { return CantidadP * PrecioUnitario; } }

        public Factura Factura { get; set; }
        public Producto Producto { get; set; }
    }
}
