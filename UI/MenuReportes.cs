using System;
using Proyecto_Restaurante.Servicios;
using Proyecto_Restaurante.Utilidades;

namespace Proyecto_Restaurante.UI
{
    // Menu para mostrar reportes del sistema
    public class MenuReportes
    {
        private ServicioPedido servicioPedido;

        // Constructor que inicializa el menu
        public MenuReportes(ServicioPedido servicioPedido)
        {
            this.servicioPedido = servicioPedido;
        }

        // Muestra el menu de reportes
        public void Mostrar()
        {
            bool continuar = true;

            while (continuar)
            {
                Validaciones.LimpiarConsola();
                Console.WriteLine("========================================");
                Console.WriteLine("             REPORTES");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Ganancias del Dia");
                Console.WriteLine("2. Historial de Platos Servidos");
                Console.WriteLine("3. Todos los Pedidos");
                Console.WriteLine("4. Volver al Menu Principal");
                Console.WriteLine("========================================");

                int opcion = Validaciones.LeerEntero("Seleccione una opcion: ");

                switch (opcion)
                {
                    case 1:
                        MostrarGananciasDelDia();
                        break;
                    case 2:
                        MostrarHistorialPlatos();
                        break;
                    case 3:
                        MostrarTodosPedidos();
                        break;
                    case 4:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("\nOpcion invalida");
                        Validaciones.PausarConsola();
                        break;
                }
            }
        }

        // Muestra las ganancias del dia
        private void MostrarGananciasDelDia()
        {
            Validaciones.LimpiarConsola();
            Console.WriteLine("===== GANANCIAS DEL DIA =====\n");

            decimal ganancias = servicioPedido.ObtenerGananciasDelDia();
            Console.WriteLine("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy"));
            Console.WriteLine("\nTotal de ganancias: $" + ganancias.ToString("N0"));

            Validaciones.PausarConsola();
        }

        // Muestra el historial de platos servidos
        private void MostrarHistorialPlatos()
        {
            Validaciones.LimpiarConsola();
            servicioPedido.MostrarHistorialPlatos();
            Validaciones.PausarConsola();
        }

        // Muestra todos los pedidos registrados
        private void MostrarTodosPedidos()
        {
            Validaciones.LimpiarConsola();
            servicioPedido.ListarTodosPedidos();
            Validaciones.PausarConsola();
        }
    }
}
