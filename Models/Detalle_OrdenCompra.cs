using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Ferreteria.Models
{
    public class Detalle_OrdenCompra
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Código")]
        public string CodDetalleFactura { get; set; }

       
        [DisplayName("Orden de Compra")]
        public int OrdenCompraId { get; set; }

       
        [DisplayName("Producto")]
        public int ProductoId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [DisplayName("Cantidad de Producto")]
        public int CantidadP { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        [DataType(DataType.Currency)]
        [DisplayName("Precio Unitario")]
        public decimal PrecioUnitario { get; set; }

        [DisplayName("Subtotal")]
        public decimal TotalDetalle { get { return CantidadP * PrecioUnitario; } }

        public OrdenCompra OrdenCompra { get; set; }
        public Producto Producto { get; set; }

    }
}
