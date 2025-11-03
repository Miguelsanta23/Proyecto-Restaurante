using System;
using Proyecto_Reastaurante.Modelos;
using Proyecto_Reastaurante.Estructuras;
using Proyecto_Reastaurante.Utilidades;

namespace SistemaRestaurante.Servicios
{
    // Servicio para gestionar clientes
    public class ServicioCliente
    {
        private ListaEnlazada<Cliente> clientes;

        // Constructor que inicializa el servicio
        public ServicioCliente()
        {
            clientes = new ListaEnlazada<Cliente>();
        }

        // Obtiene la lista de clientes
        public ListaEnlazada<Cliente> ObtenerClientes()
        {
            return clientes;
        }

        // Crea un nuevo cliente
        public bool CrearCliente(string cedula, string nombreCompleto, string celular, string email)
        {
            // Validar campos
            if (!Validaciones.ValidarCampoNoVacio(cedula) || !Validaciones.ValidarCampoNoVacio(nombreCompleto))
            {
                Console.WriteLine("Error: La cedula y el nombre son obligatorios");
                return false;
            }

            if (!Validaciones.ValidarCelular(celular))
            {
                Console.WriteLine("Error: El celular debe tener 10 dígitos");
                return false;
            }

            if (!Validaciones.ValidarEmail(email))
            {
                Console.WriteLine("Error: El email no tiene un formato valido");
                return false;
            }

            // Validar que la cedula no exista
            if (BuscarPorCedula(cedula) != null)
            {
                Console.WriteLine("Error: Ya existe un cliente con esa cedula");
                return false;
            }

            // Crear y agregar el cliente
            Cliente nuevoCliente = new Cliente(cedula, nombreCompleto, celular, email);
            clientes.Agregar(nuevoCliente);
            Console.WriteLine("Cliente creado exitosamente.");
            return true;
        }

        // Busca un cliente por su cedula
        public Cliente BuscarPorCedula(string cedula)
        {
            Nodo<Cliente> actual = clientes.Cabeza;
            while (actual != null)
            {
                if (actual.Valor.Cedula == cedula)
                {
                    return actual.Valor;
                }
                actual = actual.Siguiente;
            }
            return null;
        }
    }
}
