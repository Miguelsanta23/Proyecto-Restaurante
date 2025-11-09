using System;
using Proyecto_Restaurante.Servicios;
using Proyecto_Restaurante.UI;

namespace Proyecto_Restaurante
{
    // Clase principal del programa
    class Program
    {
        // Punto de entrada del programa
        static void Main(string[] args)
        {
            // Inicializar servicios
            ServicioRestaurante servicioRestaurante = new ServicioRestaurante();
            ServicioCliente servicioCliente = new ServicioCliente();
            ServicioPlato servicioPlato = new ServicioPlato();
            ServicioPedido servicioPedido = new ServicioPedido();

            // Mostrar menu principal
            MenuPrincipal menuPrincipal = new MenuPrincipal(servicioRestaurante, servicioCliente, 
                                                            servicioPlato, servicioPedido);
            menuPrincipal.Mostrar();
        }
    }
}