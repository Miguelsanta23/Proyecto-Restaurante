using System;
using Proyecto_Restaurante.Servicios;
using Proyecto_Restaurante.Utilidades;


namespace Proyecto_Restaurante.UI
{
    // Menu para gestionar restaurantes
    public class MenuRestaurante
    {
        private ServicioRestaurante servicioRestaurante;

        // Constructor que inicializa el menu
        public MenuRestaurante(ServicioRestaurante servicioRestaurante)
        {
            this.servicioRestaurante = servicioRestaurante;
        }

        // Muestra el menu de gestion de restaurantes
        public void Mostrar()
        {
            bool continuar = true;

            while (continuar)
            {
                Validaciones.LimpiarConsola();
                Console.WriteLine("========================================");
                Console.WriteLine("      GESTION DE RESTAURANTES");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Crear Restaurante");
                Console.WriteLine("2. Listar Restaurantes");
                Console.WriteLine("3. Editar Restaurante");
                Console.WriteLine("4. Volver al Menu Principal");
                Console.WriteLine("========================================");

                int opcion = Validaciones.LeerEntero("Seleccione una opcion: ");

                switch (opcion)
                {
                    case 1:
                        CrearRestaurante();
                        break;
                    case 2:
                        ListarRestaurantes();
                        break;
                    case 3:
                        EditarRestaurante();
                        break;
                    case 4:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("\nOpcion invalida.");
                        Validaciones.PausarConsola();
                        break;
                }
            }
        }

        // Crea un nuevo restaurante
        private void CrearRestaurante()
        {
            Validaciones.LimpiarConsola();
            Console.WriteLine("===== CREAR RESTAURANTE =====\n");

            Console.Write("Ingrese el NIT: ");
            string nit = Console.ReadLine();

            Console.Write("Ingrese el nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el nombre del dueño: ");
            string duenio = Console.ReadLine();

            Console.Write("Ingrese el celular (10 digitos): ");
            string celular = Console.ReadLine();

            Console.Write("Ingrese la direccion: ");
            string direccion = Console.ReadLine();

            servicioRestaurante.CrearRestaurante(nit, nombre, duenio, celular, direccion);
            Validaciones.PausarConsola();
        }

        // Lista todos los restaurantes
        private void ListarRestaurantes()
        {
            Validaciones.LimpiarConsola();
            servicioRestaurante.ListarRestaurantes();
            Validaciones.PausarConsola();
        }

        // Edita un restaurante existente
        private void EditarRestaurante()
        {
            Validaciones.LimpiarConsola();
            Console.WriteLine("===== EDITAR RESTAURANTE =====\n");

            servicioRestaurante.ListarRestaurantes();

            Console.Write("\nIngrese el NIT del restaurante a editar: ");
            string nit = Console.ReadLine();

            Console.Write("Ingrese el nuevo nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el nuevo nombre del dueño: ");
            string duenio = Console.ReadLine();

            Console.Write("Ingrese el nuevo celular (10 digitos): ");
            string celular = Console.ReadLine();

            Console.Write("Ingrese la nueva direccion: ");
            string direccion = Console.ReadLine();

            servicioRestaurante.EditarRestaurante(nit, nombre, duenio, celular, direccion);
            Validaciones.PausarConsola();
        }
    }
}