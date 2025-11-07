using System;
using Proyecto_Restaurante.Servicios;
using Proyecto_Restaurante.Utilidades;

namespace Proyecto_Restaurante.UI
{
    // Menu para gestionar clientes
    public class MenuCliente
    {
        private ServicioCliente servicioCliente;
        private ServicioPedido servicioPedido;

        // Constructor que inicializa el menu
        public MenuCliente(ServicioCliente servicioCliente, ServicioPedido servicioPedido)
        {
            this.servicioCliente = servicioCliente;
            this.servicioPedido = servicioPedido;
        }

        // Muestra el menu de gestion de clientes
        public void Mostrar()
        {
            bool continuar = true;

            while (continuar)
            {
                Validaciones.LimpiarConsola();
                Console.WriteLine("========================================");
                Console.WriteLine("         GESTION DE CLIENTES");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Crear Cliente");
                Console.WriteLine("2. Listar Clientes");
                Console.WriteLine("3. Editar Cliente");
                Console.WriteLine("4. Borrar Cliente");
                Console.WriteLine("5. Volver al Menu Principal");
                Console.WriteLine("========================================");

                int opcion = Validaciones.LeerEntero("Seleccione una opcion: ");

                switch (opcion)
                {
                    case 1:
                        CrearCliente();
                        break;
                    case 2:
                        ListarClientes();
                        break;
                    case 3:
                        EditarCliente();
                        break;
                    case 4:
                        BorrarCliente();
                        break;
                    case 5:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("\nOpcion invalida");
                        Validaciones.PausarConsola();
                        break;
                }
            }
        }

        // Crea un nuevo cliente
        private void CrearCliente()
        {
            Validaciones.LimpiarConsola();
            Console.WriteLine("===== CREAR CLIENTE =====\n");

            Console.Write("Ingrese la cedula: ");
            string cedula = Console.ReadLine();

            Console.Write("Ingrese el nombre completo: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el celular (10 digitos): ");
            string celular = Console.ReadLine();

            Console.Write("Ingrese el email: ");
            string email = Console.ReadLine();

            servicioCliente.CrearCliente(cedula, nombre, celular, email);
            Validaciones.PausarConsola();
        }

        // Lista todos los clientes
        private void ListarClientes()
        {
            Validaciones.LimpiarConsola();
            servicioCliente.ListarClientes();
            Validaciones.PausarConsola();
        }

        // Edita un cliente existente
        private void EditarCliente()
        {
            Validaciones.LimpiarConsola();
            Console.WriteLine("===== EDITAR CLIENTE =====\n");

            servicioCliente.ListarClientes();

            Console.Write("\nIngrese la cedula del cliente a editar: ");
            string cedula = Console.ReadLine();

            Console.Write("Ingrese el nuevo nombre completo: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el nuevo celular (10 digitos): ");
            string celular = Console.ReadLine();

            Console.Write("Ingrese el nuevo email: ");
            string email = Console.ReadLine();

            servicioCliente.EditarCliente(cedula, nombre, celular, email);
            Validaciones.PausarConsola();
        }

        // Borra un cliente que no tenga pedidos pendientes
        private void BorrarCliente()
        {
            Validaciones.LimpiarConsola();
            Console.WriteLine("===== BORRAR CLIENTE =====\n");

            servicioCliente.ListarClientes();

            Console.Write("\nIngrese la cedula del cliente a borrar: ");
            string cedula = Console.ReadLine();

            // Verificar si tiene pedidos pendientes
            if (servicioPedido.ClienteTienePedidosPendientes(cedula))
            {
                Console.WriteLine("\nError: El cliente tiene pedidos PENDIENTES");
                Console.WriteLine("No se puede eliminar hasta que todos sus pedidos esten despachados");
            }
            else
            {
                Console.Write("\n¿Esta seguro de eliminar este cliente? (S/N): ");
                string confirmacion = Console.ReadLine();

                if (confirmacion.ToUpper() == "S")
                {
                    servicioCliente.BorrarCliente(cedula);
                }
                else
                {
                    Console.WriteLine("Operacion cancelada");
                }
            }

            Validaciones.PausarConsola();
        }
    }
}
