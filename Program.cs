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

            // Cargar datos de ejemplo
            CargarDatosEjemplo(servicioRestaurante, servicioCliente, servicioPlato);

            // Mostrar menu principal
            MenuPrincipal menuPrincipal = new MenuPrincipal(servicioRestaurante, servicioCliente,
                                                            servicioPlato, servicioPedido);
            menuPrincipal.Mostrar();
        }

        // Carga datos de ejemplo para probar el sistema
        static void CargarDatosEjemplo(ServicioRestaurante servicioRestaurante, ServicioCliente servicioCliente, ServicioPlato servicioPlato)
        {
            Console.WriteLine("Cargando datos de ejemplo...\n");

            // Crear restaurante de ejemplo
            servicioRestaurante.CrearRestaurante("900123456", "Restaurante El Sabor", 
                                                 "Juan Perez", "3001234567", 
                                                 "Calle 10 #20-30");

            // Crear clientes de ejemplo
            servicioCliente.CrearCliente("1234567890", "Maria Garcia", "3009876543", 
                                        "maria.garcia@email.com");
            servicioCliente.CrearCliente("9876543210", "Carlos Lopez", "3101234567", 
                                        "carlos.lopez@email.com");
            servicioCliente.CrearCliente("5555555555", "Ana Martínez", "3207654321", 
                                        "ana.martinez@email.com");

            // Crear platos de ejemplo
            servicioPlato.CrearPlato("P001", "Bandeja Paisa", 
                                    "Plato tipico con carne, chicharron, arroz, frijoles", 
                                    25000);
            servicioPlato.CrearPlato("P002", "Ajiaco Santafereño", 
                                    "Sopa tradicional con pollo y papas", 
                                    18000);
            servicioPlato.CrearPlato("P003", "Arroz con Pollo", 
                                    "Arroz amarillo con pollo y verduras", 
                                    15000);
            servicioPlato.CrearPlato("P004", "Sancocho de Gallina", 
                                    "Sopa con gallina criolla y plátano", 
                                    20000);
            servicioPlato.CrearPlato("P005", "Mojarra Frita", 
                                    "Mojarra frita con patacón y ensalada", 
                                    22000);
            servicioPlato.CrearPlato("P006", "Cazuela de Mariscos", 
                                    "Mariscos en salsa criolla", 
                                    28000);
            servicioPlato.CrearPlato("P007", "Lomo de Cerdo", 
                                    "Lomo en salsa BBQ con papas", 
                                    24000);
            servicioPlato.CrearPlato("P008", "Pechuga a la Plancha", 
                                    "Pechuga de pollo con arroz y ensalada", 
                                    16000);

            Console.WriteLine("Datos de ejemplo cargados exitosamente\n");
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
        }
    }
}