namespace Proyecto_Reastaurante.Modelos
{
    public class Restaurante
    {
        // Representa un restaurante en el sistema
        private string nit;
        private string nombre;
        private string duenio;
        private string celular;
        private string direccion;

        // Constructor que crea el restaurante con todos sus datos
        public Restaurante(
            string nit,
            string nombre,
            string duenio,
            string celular,
            string direccion)
        {
            this.nit = nit;
            this.nombre = nombre;
            this.duenio = duenio;
            this.celular = celular;
            this.direccion = direccion;
        }

        // Esctablece el NIT del restaurante
        public string Nit
        {
            get { return this.nit; }
            set { this.nit = value; }
        }

        // Establece el nombre del restaurante
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        // Establece el nombre del dueño
        public string Duenio
        {
            get { return this.duenio; }
            set { this.duenio = value; }
        }

        // Establece el celular del restaurante
        public string Celular
        {
            get { return this.celular; }
            set { this.celular = value; }
        }

        // Establece la direccion del restaurante
        public string Direccion
        {
            get { return this.direccion; }
            set { this.direccion = value; }
        }

        // Retorna la informacion del restaurante
        public override string ToString()
        {
            return "NIT: " + nit + "/n" + "Nombre: " + nombre + "/n" + "Dueño: " + duenio + "/n" + "Celular: " + celular + "/n" + "Direccion: " + direccion;
        }
    }
}
