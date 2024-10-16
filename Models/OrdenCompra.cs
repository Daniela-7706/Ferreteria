using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Ferreteria.Models
{
    public class OrdenCompra
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Código OrdenCompra")]
        public string CodOrdenCompra { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DisplayName("Fecha de Pedido")]
        public string FechaPedOrdCom { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DisplayName("Fecha de Entrega")]
        public string FechaEntOrdCom { get; set; }

        [DisplayName("Nit")]
        public int ProveedorId { get; set; }

        [DisplayName("Proveedor")]
        public string NombreProveedor { get; set; }

        public List<Detalle_OrdenCompra> Detalles { get; set; } = new List<Detalle_OrdenCompra>();

        [DisplayName("Total")]
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

        public Proveedor Proveedor { get; set; }
    }
}
