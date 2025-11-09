using System;
using Proyecto_Restaurante.Modelos;
using Proyecto_Restaurante.Servicios;
using Proyecto_Restaurante.Utilidades;

namespace Proyecto_Restaurante.UI
{
    // Menu para gestionar pedidos
    public class MenuPedido
    {
        private ServicioCliente servicioCliente;
        private ServicioPlato servicioPlato;
        private ServicioPedido servicioPedido;

        // Constructor que inicializa el menu
        public MenuPedido(ServicioCliente servicioCliente, ServicioPlato servicioPlato, ServicioPedido servicioPedido)
        {
            this.servicioCliente = servicioCliente;
            this.servicioPlato = servicioPlato;
            this.servicioPedido = servicioPedido;
        }

        // Muestra el menu de gestion de pedidos
        public void Mostrar()
        {
            bool continuar = true;

            while (continuar)
            {
                Validaciones.LimpiarConsola();
                Console.WriteLine("========================================");
                Console.WriteLine("         GESTION DE PEDIDOS");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Tomar Pedido");
                Console.WriteLine("2. Despachar Pedido");
                Console.WriteLine("3. Ver Pedidos Pendientes");
                Console.WriteLine("4. Ver Todos los Pedidos");
                Console.WriteLine("5. Volver al Menu Principal");
                Console.WriteLine("========================================");

                int opcion = Validaciones.LeerEntero("Seleccione una opcion: ");

                switch (opcion)
                {
                    case 1:
                        TomarPedido();
                        break;
                    case 2:
                        DespacharPedido();
                        break;
                    case 3:
                        VerPedidosPendientes();
                        break;
                    case 4:
                        VerTodosPedidos();
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

        // Toma un nuevo pedido
        private void TomarPedido()
        {
            Validaciones.LimpiarConsola();
            Console.WriteLine("===== TOMAR PEDIDO =====\n");

            // Mostrar clientes
            servicioCliente.ListarClientes();

            Console.Write("\nIngrese la cedula del cliente: ");
            string cedula = Console.ReadLine();

            Cliente cliente = servicioCliente.BuscarPorCedula(cedula);

            if (cliente == null)
            {
                Console.WriteLine("Error: Cliente no encontrado");
                Validaciones.PausarConsola();
                return;
            }

            // Crear el pedido
            Pedido pedido = servicioPedido.CrearPedido(cliente);

            if (pedido == null)
            {
                Validaciones.PausarConsola();
                return;
            }

            Console.WriteLine("\nPedido iniciado para: " + cliente.NombreCompleto);

            bool agregarMasPlatos = true;

            while (agregarMasPlatos)
            {
                // Mostrar menu
                Console.WriteLine("\n");
                servicioPlato.ListarPlatos();

                Console.Write("\nIngrese el codigo del plato (o 0 para terminar): ");
                string codigoPlato = Console.ReadLine();

                if (codigoPlato == "0")
                {
                    agregarMasPlatos = false;
                    continue;
                }

                Plato plato = servicioPlato.BuscarPorCodigo(codigoPlato);

                if (plato == null)
                {
                    Console.WriteLine("Error: Plato no encontrado");
                    continue;
                }

                int cantidad = Validaciones.LeerEntero("Ingrese la cantidad: ");

                servicioPedido.AgregarPlatoAlPedido(pedido, plato, cantidad);

                Console.Write("\n¿Desea agregar otro plato? (S/N): ");
                string respuesta = Console.ReadLine();

                if (respuesta.ToUpper() != "S")
                {
                    agregarMasPlatos = false;
                }
            }

            // Mostrar resumen del pedido
            if (!pedido.Platos.EstaVacia())
            {
                pedido.CalcularTotal();
                Console.WriteLine("\n===== RESUMEN DEL PEDIDO =====");
                Console.WriteLine("Cliente: " + pedido.NombreCliente);
                Console.WriteLine("\nPlatos:");

                Estructuras.Nodo<PlatoPedido> actual = pedido.Platos.Cabeza;
                while (actual != null)
                {
                    Console.WriteLine("  - " + actual.Valor.ToString());
                    actual = actual.Siguiente;
                }

                Console.WriteLine("\nTOTAL: $" + pedido.Total.ToString("N0"));

                Console.Write("\n¿Confirmar pedido? (S/N): ");
                string confirmar = Console.ReadLine();

                if (confirmar.ToUpper() == "S")
                {
                    servicioPedido.ConfirmarPedido(pedido);
                }
                else
                {
                    Console.WriteLine("Pedido cancelado");
                }
            }
            else
            {
                Console.WriteLine("\nNo se agregaron platos al pedido");
            }

            Validaciones.PausarConsola();
        }

        // Despacha el siguiente pedido en la cola
        private void DespacharPedido()
        {
            Validaciones.LimpiarConsola();
            Console.WriteLine("===== DESPACHAR PEDIDO =====\n");

            servicioPedido.DespacharPedido();
            Validaciones.PausarConsola();
        }

        // Muestra los pedidos pendientes
        private void VerPedidosPendientes()
        {
            Validaciones.LimpiarConsola();
            servicioPedido.MostrarPedidosPendientes();
            Validaciones.PausarConsola();
        }

        // Muestra todos los pedidos
        private void VerTodosPedidos()
        {
            Validaciones.LimpiarConsola();
            servicioPedido.ListarTodosPedidos();
            Validaciones.PausarConsola();
        }
    }
}
