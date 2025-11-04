namespace Proyecto_Restaurante.Modelos
{
    // Representa un plato dentro de un pedido con su cantidad
    public class PlatoPedido
    {
        private string codigoPlato;
        private string nombrePlato;
        private int cantidad;
        private decimal precioUnitario;

        // Constructor que inicializa un plato pedido con sus datos
        public PlatoPedido(string codigoPlato, string nombrePlato, int cantidad, decimal precioUnitario)
        {
            this.codigoPlato = codigoPlato;
            this.nombrePlato = nombrePlato;
            this.cantidad = cantidad;
            this.precioUnitario = precioUnitario;
        }

        // Establece el codigo del plato
        public string CodigoPlato
        {
            get { return this.codigoPlato; }
            set { this.codigoPlato = value; }
        }

        // Establece el nombre del plato
        public string NombrePlato
        {
            get { return this.nombrePlato; }
            set { this.nombrePlato = value; }
        }

        // Establece la cantidad pedida
        public int Cantidad
        {
            get { return this.cantidad; }
            set { this.cantidad = value; }
        }

        // Establece el precio unitario del plato
        public decimal PrecioUnitario
        {
            get { return this.precioUnitario; }
            set { this.precioUnitario = value; }
        }

        // Calcula el subtotal de este plato en el pedido
        public decimal CalcularSubtotal()
        {
            return precioUnitario * cantidad;
        }

        // Retorna la informacion del plato pedido
        public override string ToString()
        {
            return nombrePlato + " x" + cantidad + " - $" + CalcularSubtotal().ToString("N0");
        }
    }
}
