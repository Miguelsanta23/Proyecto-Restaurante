namespace Proyecto_Reastaurante.Modelos
{
    // Representa un plato del menu del restaurante
    public class Plato
    {
        private string codigo;
        private string nombre;
        private string descripcion;
        private decimal precio;

        // Constructor que inicializa un plato con todos sus datos
        public Plato(string codigo, string nombre, string descripcion, decimal precio)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
        }

        // Establece el código del plato
        public string Codigo
        {
            get { return this.codigo; }
            set { this.codigo = value; }
        }

        // Establece el nombre del plato
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        // Establece la descripción del plato
        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }

        // Establece el precio del plato
        public decimal Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }

        // Retorna la informacion del plato
        public override string ToString()
        {
            return "Codigo: " + codigo + "\n" + "Nombre: " + nombre + "\n" + "Descripcion: " + descripcion + "\n" + "Precio: $" + precio.ToString("N0");
        }
    }
}
