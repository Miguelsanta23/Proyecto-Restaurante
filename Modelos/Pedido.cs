using System;
using Proyecto_Restaurante.Estructuras;

namespace Proyecto_Restaurante.Modelos
{
    // Representa un pedido realizado por un cliente
    public class Pedido
    {
        private static int contadorId = 1;
        private int idPedido;
        private string cedulaCliente;
        private string nombreCliente;
        private ListaEnlazada<PlatoPedido> platos;
        private decimal total;
        private DateTime fechaHora;
        private string estado;

        // Constructor que inicializa un pedido
        public Pedido(string cedulaCliente, string nombreCliente)
        {
            this.idPedido = contadorId++;
            this.cedulaCliente = cedulaCliente;
            this.nombreCliente = nombreCliente;
            this.platos = new ListaEnlazada<PlatoPedido>();
            this.total = 0;
            this.fechaHora = DateTime.Now;
            this.estado = "PENDIENTE";
        }

        /// Obtiene el ID del pedido
        public int IdPedido
        {
            get { return this.idPedido; }
        }

        // Establece la cedula del cliente
        public string CedulaCliente
        {
            get { return this.cedulaCliente; }
            set { this.cedulaCliente = value; }
        }

        // Establece el nombre del cliente
        public string NombreCliente
        {
            get { return this.nombreCliente; }
            set { this.nombreCliente = value; }
        }

        // Obtiene la lista de platos del pedido
        public ListaEnlazada<PlatoPedido> Platos
        {
            get { return this.platos; }
        }

        // Establece el total del pedido
        public decimal Total
        {
            get { return this.total; }
            set { this.total = value; }
        }

        // Obtiene la fecha y hora del pedido
        public DateTime FechaHora
        {
            get { return this.fechaHora; }
        }

        // Establece el estado del pedido
        public string Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        // Agrega un plato al pedido
        public void AgregarPlato(PlatoPedido platoPedido)
        {
            platos.Agregar(platoPedido);
            total = total + platoPedido.CalcularSubtotal();
        }

        // Calcula el total del pedido sumando todos los platos
        public void CalcularTotal()
        {
            total = 0;
            Nodo<PlatoPedido> actual = platos.Cabeza;
            while (actual != null)
            {
                total = total + actual.Valor.CalcularSubtotal();
                actual = actual.Siguiente;
            }
        }

        // Marca el pedido como despachado
        public void MarcarDespachado()
        {
            estado = "DESPACHADO";
        }

        // Retorna la informacion del pedido del pedido
        public override string ToString()
        {
            return "Pedido #" + idPedido + "/n" + "Cliente: " + nombreCliente + "/n" + "Total: $" + total.ToString("N0") + "/n" + "Estado: " + estado;
        }
    }
}
