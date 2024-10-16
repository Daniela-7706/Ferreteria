using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Ferreteria.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Nombre del producto")]
        public string Nombre { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        [DataType(DataType.Currency)]
        [DisplayName("Precio del producto")]
        public decimal PrecioProducto { get; set; }

        [StringLength(15)]
        [DisplayName("Unidad de Medida del producto")]
        public string UProducto { get; set; }

        [DisplayName("Proveedor del producto")]
        public int ProveedorId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Unidades Disponibles")]
        public int UnidadesDisponibles { get; set; }

        public bool Disponible { get { return UnidadesDisponibles > 0; } }

        public Proveedor Proveedor { get; set; }

        
    }
}
