namespace Proyecto_Reastaurante.Modelos
{
    // Representa un cliente del restaurante
    public class Cliente
    {
        private string cedula;
        private string nombreCompleto;
        private string celular;
        private string email;

        // Constructor que crea al cliente con todos sus datos
        public Cliente(string cedula, string nombreCompleto, string celular, string email)
        {
            this.cedula = cedula;
            this.nombreCompleto = nombreCompleto;
            this.celular = celular;
            this.email = email;
        }

        // Establece la cedula del cliente
        public string Cedula
        {
            get { return this.cedula; }
            set { this.cedula = value; }
        }

        // Establece el nombre completo del cliente
        public string NombreCompleto
        {
            get { return this.nombreCompleto; }
            set { this.nombreCompleto = value; }
        }

        // Establece el celular del cliente
        public string Celular
        {
            get { return this.celular; }
            set { this.celular = value; }
        }

        // Establece el email del cliente
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        // Retorna la informacion del cliente
        public override string ToString()
        {
            return "Cedula: " + cedula + "/n" + "Nombre: " + nombreCompleto + "/n" + "Celular: " + celular + "/n" + "Email: " + email;
        }
    }
}
