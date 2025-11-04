using System;
using Proyecto_Restaurante.Modelos;
using Proyecto_Restaurante.Estructuras;

namespace Proyecto_Restaurante.Servicios
{
    // Servicio para gestionar pedidos
    public class ServicioPedido
    {
        private Cola<Pedido> colaPedidos;
        private ListaEnlazada<Pedido> todosPedidos;
        private Pila<string> historialPlatos;
        private decimal gananciasDelDia;

        // Constructor que inicializa el servicio
        public ServicioPedido()
        {
            colaPedidos = new Cola<Pedido>();
            todosPedidos = new ListaEnlazada<Pedido>();
            historialPlatos = new Pila<string>();
            gananciasDelDia = 0;
        }

        // Obtiene la cola de pedidos pendientes
        public Cola<Pedido> ObtenerColaPedidos()
        {
            return colaPedidos;
        }

        // Obtiene todos los pedidos
        public ListaEnlazada<Pedido> ObtenerTodosPedidos()
        {
            return todosPedidos;
        }

        // Obtiene el historial de platos servidos
        public Pila<string> ObtenerHistorialPlatos()
        {
            return historialPlatos;
        }

        // Crea un nuevo pedido y lo agrega a la cola
        public Pedido CrearPedido(Cliente cliente)
        {
            if (cliente == null)
            {
                Console.WriteLine("Error: El cliente no existe");
                return null;
            }

            Pedido nuevoPedido = new Pedido(cliente.Cedula, cliente.NombreCompleto);
            return nuevoPedido;
        }

        // Agrega un plato al pedido actual
        public bool AgregarPlatoAlPedido(Pedido pedido, Plato plato, int cantidad)
        {
            if (pedido == null || plato == null)
            {
                Console.WriteLine("Error: Pedido o plato invalido.");
                return false;
            }

            if (cantidad <= 0)
            {
                Console.WriteLine("Error: La cantidad debe ser mayor a cero.");
                return false;
            }

            PlatoPedido platoPedido = new PlatoPedido(plato.Codigo, plato.Nombre, cantidad, plato.Precio);
            pedido.AgregarPlato(platoPedido);
            Console.WriteLine("Plato agregado al pedido: " + platoPedido.ToString());
            return true;
        }

        // Confirma el pedido y lo encola
        public bool ConfirmarPedido(Pedido pedido)
        {
            if (pedido == null)
            {
                Console.WriteLine("Error: Pedido invalido");
                return false;
            }

            if (pedido.Platos.EstaVacia())
            {
                Console.WriteLine("Error: El pedido no tiene platos");
                return false;
            }

            pedido.CalcularTotal();
            colaPedidos.Agregar(pedido);
            todosPedidos.Agregar(pedido);
            Console.WriteLine("\nPedido confirmado y agregado exitosamente");
            Console.WriteLine(pedido.ToString());
            return true;
        }

        // Despacha el siguiente pedido en la cola
        public bool DespacharPedido()
        {
            if (colaPedidos.EstaVacia())
            {
                Console.WriteLine("No hay pedidos pendientes para despachar");
                return false;
            }

            Pedido pedido = colaPedidos.Desencolar();
            pedido.MarcarDespachado();

            // Agregar platos al historial
            Nodo<PlatoPedido> actual = pedido.Platos.Cabeza;
            while (actual != null)
            {
                string infoPlato = actual.Valor.NombrePlato + " x" + actual.Valor.Cantidad;
                historialPlatos.Apilar(infoPlato);
                actual = actual.Siguiente;
            }

            // Sumar a ganancias del dia
            gananciasDelDia = gananciasDelDia + pedido.Total;

            Console.WriteLine("\n===== PEDIDO DESPACHADO =====");
            Console.WriteLine(pedido.ToString());
            Console.WriteLine("Fecha: " + pedido.FechaHora.ToString("dd/MM/yyyy HH:mm"));
            Console.WriteLine("\nPlatos despachados:");
            MostrarPlatosPedido(pedido);

            return true;
        }

        // Muestra los platos de un pedido
        private void MostrarPlatosPedido(Pedido pedido)
        {
            Nodo<PlatoPedido> actual = pedido.Platos.Cabeza;
            while (actual != null)
            {
                Console.WriteLine("  - " + actual.Valor.ToString());
                actual = actual.Siguiente;
            }
        }

        // Muestra los pedidos pendientes en la cola
        public void MostrarPedidosPendientes()
        {
            if (colaPedidos.EstaVacia())
            {
                Console.WriteLine("No hay pedidos pendientes");
                return;
            }

            Console.WriteLine("\n===== PEDIDOS PENDIENTES =====");
            Console.WriteLine("Total en cola: " + colaPedidos.Tamano());
            colaPedidos.Imprimir();
        }

        // Obtiene las ganancias del dia
        public decimal ObtenerGananciasDelDia()
        {
            return gananciasDelDia;
        }

        // Muestra el historial de platos servidos
        public void MostrarHistorialPlatos()
        {
            if (historialPlatos.EstaVacia())
            {
                Console.WriteLine("No hay platos en el historial");
                return;
            }

            Console.WriteLine("\n===== HISTORIAL DE PLATOS SERVIDOS =====");
            historialPlatos.Imprimir();
        }

        // Verifica si un cliente tiene pedidos pendientes
        public bool ClienteTienePedidosPendientes(string cedula)
        {
            Nodo<Pedido> actual = todosPedidos.Cabeza;
            while (actual != null)
            {
                if (actual.Valor.CedulaCliente == cedula && actual.Valor.Estado == "PENDIENTE")
                {
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false;
        }

        // Verifica si un plato está en pedidos pendientes
        public bool PlatoEnPedidosPendientes(string codigoPlato)
        {
            Nodo<Pedido> actual = todosPedidos.Cabeza;
            while (actual != null)
            {
                if (actual.Valor.Estado == "PENDIENTE")
                {
                    Nodo<PlatoPedido> actualPlato = actual.Valor.Platos.Cabeza;
                    while (actualPlato != null)
                    {
                        if (actualPlato.Valor.CodigoPlato == codigoPlato)
                        {
                            return true;
                        }
                        actualPlato = actualPlato.Siguiente;
                    }
                }
                actual = actual.Siguiente;
            }
            return false;
        }

        // Lista todos los pedidos
        public void ListarTodosPedidos()
        {
            if (todosPedidos.EstaVacia())
            {
                Console.WriteLine("No hay pedidos registrados");
                return;
            }

            Console.WriteLine("\n===== TODOS LOS PEDIDOS =====");
            Nodo<Pedido> actual = todosPedidos.Cabeza;
            int contador = 1;

            while (actual != null)
            {
                Pedido p = actual.Valor;
                Console.WriteLine("\n" + contador + ". " + p.ToString());
                Console.WriteLine("   Fecha: " + p.FechaHora.ToString("dd/MM/yyyy HH:mm"));
                Console.WriteLine("   Platos:");
                
                Nodo<PlatoPedido> actualPlato = p.Platos.Cabeza;
                while (actualPlato != null)
                {
                    Console.WriteLine("      - " + actualPlato.Valor.ToString());
                    actualPlato = actualPlato.Siguiente;
                }
                
                actual = actual.Siguiente;
                contador++;
            }
        }
    }
}
