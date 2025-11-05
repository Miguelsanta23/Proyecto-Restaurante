using System;
using Proyecto_Restaurante.Servicios;
using Proyecto_Restaurante.Utilidades;

namespace Proyecto_Restaurante.UI
{
    // Menu principal del sistema
    public class MenuPrincipal
    {
        private ServicioRestaurante servicioRestaurante;
        private ServicioCliente servicioCliente;
        private ServicioPlato servicioPlato;
        private ServicioPedido servicioPedido;

        // Constructor que inicializa el menu con los servicios
        public MenuPrincipal(ServicioRestaurante servicioRestaurante, ServicioCliente servicioCliente, ServicioPlato servicioPlato, ServicioPedido servicioPedido)
        {
            this.servicioRestaurante = servicioRestaurante;
            this.servicioCliente = servicioCliente;
            this.servicioPlato = servicioPlato;
            this.servicioPedido = servicioPedido;
        }

        // Muestra el menu principal
        public void Mostrar()
        {
            bool continuar = true;

            while (continuar)
            {
                Validaciones.LimpiarConsola();
                Console.WriteLine("========================================");
                Console.WriteLine("   SISTEMA DE GESTION DE RESTAURANTE   ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Gestion de Restaurantes");
                Console.WriteLine("2. Gestion de Clientes");
                Console.WriteLine("3. Gestion del Menu");
                Console.WriteLine("4. Gestion de pedidos");
                Console.WriteLine("5. Reportes");
                Console.WriteLine("6. Salir");
                Console.WriteLine("========================================");

                int opcion = Validaciones.LeerEntero("Seleccione una opcion: ");

                switch (opcion)
                {
                    case 1:
                        MenuRestaurante menuRestaurante = new MenuRestaurante(servicioRestaurante);
                        menuRestaurante.Mostrar();
                        break;
                    case 2:
                        MenuCliente menuCliente = new MenuCliente(servicioCliente, servicioPedido);
                        menuCliente.Mostrar();
                        break;
                    case 3:
                        MenuPlato menuPlato = new MenuPlato(servicioPlato, servicioPedido);
                        menuPlato.Mostrar();
                        break;
                    case 4:
                        MenuPedido menuPedido = new MenuPedido(servicioCliente, servicioPlato, servicioPedido);
                        menuPedido.Mostrar();
                        break;
                    case 5:
                        MenuReportes menuReportes = new MenuReportes(servicioPedido);
                        menuReportes.Mostrar();
                        break;
                    case 6:
                        Console.WriteLine("\nSistema terminado, gracias por usarlo");
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("\nOpcion invalida");
                        Validaciones.PausarConsola();
                        break;
                }
            }
        }
    }
}