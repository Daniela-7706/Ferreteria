using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Ferreteria.Models
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }

        [StringLength(16)]
        [Required]
        public string Nit { get; set; }

        [StringLength(40)]
        [Required]
        [DisplayName("Nombre del Proveedor")]
        public string Nombre { get; set; }

        [DisplayName("Dirección")]
        [StringLength(40)]
        [Required]
        public string Direccion { get; set; }

        [DisplayName("Teléfono")]
        [StringLength(20)]
        [Required]
        public string Telefono { get; set; }

        [DisplayName("Correo Electrónico")]
        [StringLength(30)]
        public string Email { get; set; }

        public virtual ICollection<OrdenCompra> OrdenCompras { get; set; }
    }
}
