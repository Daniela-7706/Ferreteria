namespace Ferreteria.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }


    }
}
