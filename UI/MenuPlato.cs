using System;
using Proyecto_Restaurante.Servicios;
using Proyecto_Restaurante.Utilidades;

namespace Proyecto_Restaurante.UI
{
    // Menu para gestionar platos del menu
    public class MenuPlato
    {
        private ServicioPlato servicioPlato;
        private ServicioPedido servicioPedido;

        // Constructor que inicializa el menu
        public MenuPlato(ServicioPlato servicioPlato, ServicioPedido servicioPedido)
        {
            this.servicioPlato = servicioPlato;
            this.servicioPedido = servicioPedido;
        }

        // Muestra el menu de gestion de platos
        public void Mostrar()
        {
            bool continuar = true;

            while (continuar)
            {
                Validaciones.LimpiarConsola();
                Console.WriteLine("========================================");
                Console.WriteLine("      GESTION DE PLATOS (MENU)");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Crear Plato");
                Console.WriteLine("2. Listar Platos");
                Console.WriteLine("3. Editar Plato");
                Console.WriteLine("4. Borrar Plato");
                Console.WriteLine("5. Volver al Menu Principal");
                Console.WriteLine("========================================");

                int opcion = Validaciones.LeerEntero("Seleccione una opcion: ");

                switch (opcion)
                {
                    case 1:
                        CrearPlato();
                        break;
                    case 2:
                        ListarPlatos();
                        break;
                    case 3:
                        EditarPlato();
                        break;
                    case 4:
                        BorrarPlato();
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

        // Crea un nuevo plato
        private void CrearPlato()
        {
            Validaciones.LimpiarConsola();
            Console.WriteLine("===== CREAR PLATO =====\n");

            Console.Write("Ingrese el codigo del plato: ");
            string codigo = Console.ReadLine();

            Console.Write("Ingrese el nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese la descripcion: ");
            string descripcion = Console.ReadLine();

            decimal precio = Validaciones.LeerDecimal("Ingrese el precio: ");

            servicioPlato.CrearPlato(codigo, nombre, descripcion, precio);
            Validaciones.PausarConsola();
        }

        // Lista todos los platos
        private void ListarPlatos()
        {
            Validaciones.LimpiarConsola();
            servicioPlato.ListarPlatos();
            Validaciones.PausarConsola();
        }

        // Edita un plato existente
        private void EditarPlato()
        {
            Validaciones.LimpiarConsola();
            Console.WriteLine("===== EDITAR PLATO =====\n");

            servicioPlato.ListarPlatos();

            Console.Write("\nIngrese el codigo del plato a editar: ");
            string codigo = Console.ReadLine();

            Console.Write("Ingrese el nuevo nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese la nueva descripcion: ");
            string descripcion = Console.ReadLine();

            decimal precio = Validaciones.LeerDecimal("Ingrese el nuevo precio: ");

            servicioPlato.EditarPlato(codigo, nombre, descripcion, precio);
            Validaciones.PausarConsola();
        }

        // Borra un plato que no este en pedidos pendientes
        private void BorrarPlato()
        {
            Validaciones.LimpiarConsola();
            Console.WriteLine("===== BORRAR PLATO =====\n");

            servicioPlato.ListarPlatos();

            Console.Write("\nIngrese el codigo del plato a borrar: ");
            string codigo = Console.ReadLine();

            // Verificar si esta en pedidos pendientes
            if (servicioPedido.PlatoEnPedidosPendientes(codigo))
            {
                Console.WriteLine("\nError: El plato esta en pedidos PENDIENTES");
                Console.WriteLine("No se puede eliminar hasta que todos los pedidos esten despachados.");
            }
            else
            {
                Console.Write("\n¿Esta seguro de eliminar este plato? (S/N): ");
                string confirmacion = Console.ReadLine();

                if (confirmacion.ToUpper() == "S")
                {
                    servicioPlato.BorrarPlato(codigo);
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
