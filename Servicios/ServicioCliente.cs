using System;
using Proyecto_Restaurante.Modelos;
using Proyecto_Restaurante.Estructuras;
using Proyecto_Restaurante.Utilidades;

namespace Proyecto_Restaurante.Servicios
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

        // Lista todos los clientes
        public void ListarClientes()
        {
            if (clientes.EstaVacia())
            {
                Console.WriteLine("No hay clientes registrados");
                return;
            }

            Console.WriteLine("\n===== LISTA DE CLIENTES =====");
            Nodo<Cliente> actual = clientes.Cabeza;
            int contador = 1;

            while (actual != null)
            {
                Cliente c = actual.Valor;
                Console.WriteLine("\n" + contador + ". " + c.ToString());
                Console.WriteLine("   Email: " + c.Email);
                actual = actual.Siguiente;
                contador++;
            }
        }

        // Edita un cliente existente
        public bool EditarCliente(string cedula, string nuevoNombre, string nuevoCelular, string nuevoEmail)
        {
            Cliente cliente = BuscarPorCedula(cedula);

            if (cliente == null)
            {
                Console.WriteLine("Error: No se encontro el cliente con esa cedula");
                return false;
            }

            // Validar campos
            if (!Validaciones.ValidarCampoNoVacio(nuevoNombre))
            {
                Console.WriteLine("Error: El nombre es obligatorio");
                return false;
            }

            if (!Validaciones.ValidarCelular(nuevoCelular))
            {
                Console.WriteLine("Error: El celular debe tener 10 digitos");
                return false;
            }

            if (!Validaciones.ValidarEmail(nuevoEmail))
            {
                Console.WriteLine("Error: El email no tiene un formato valido");
                return false;
            }

            // Actualizar datos
            cliente.NombreCompleto = nuevoNombre;
            cliente.Celular = nuevoCelular;
            cliente.Email = nuevoEmail;

            Console.WriteLine("Cliente actualizado exitosamente");
            return true;
        }

        // Borrar un cliente (debe validarse primero que no tenga pedidos pendientes)
        public bool BorrarCliente(string cedula)
        {
            Cliente cliente = BuscarPorCedula(cedula);

            if (cliente == null)
            {
                Console.WriteLine("Error: No se encontro el cliente con esa cedula");
                return false;
            }

            // Eliminar el cliente de la lista
            bool eliminado = false;
            if (clientes.Cabeza != null && clientes.Cabeza.Valor.Cedula == cedula)
            {
                clientes.EliminarPosicion(0);
                eliminado = true;
            }
            else
            {
                Nodo<Cliente> actual = clientes.Cabeza;
                int posicion = 0;
                while (actual != null)
                {
                    if (actual.Valor.Cedula == cedula)
                    {
                        clientes.EliminarPosicion(posicion);
                        eliminado = true;
                        break;
                    }
                    actual = actual.Siguiente;
                    posicion++;
                }
            }

            if (eliminado)
            {
                Console.WriteLine("Cliente eliminado exitosamente");
            }

            return eliminado;
        }
    }
}
