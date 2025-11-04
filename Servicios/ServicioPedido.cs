using System;
using Proyecto_Reastaurante.Modelos;
using Proyecto_Reastaurante.Estructuras;

namespace Proyecto_Reastaurante.Servicios
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
    }
}
