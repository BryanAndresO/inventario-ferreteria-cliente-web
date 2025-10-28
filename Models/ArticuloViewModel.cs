namespace inventario_ferreteria_cliente.Models
{
    public class ArticuloViewModel
    {
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal Preciocompra { get; set; }
        public decimal Precioventa { get; set; }
        public int Stock { get; set; }
        public string Proveedor { get; set; } = string.Empty;
        public int? Stockminimo { get; set; }
    }
}
